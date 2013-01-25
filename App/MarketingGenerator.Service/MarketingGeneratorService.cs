using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceProcess;
using log4net;
using MarketingGenerator.Core;
using Tamir.SharpSsh;

namespace MarketingGenerator.Service
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MarketingGeneratorService : ServiceBase
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly FileSystemWatcher _watcher;
        private readonly FileSystemWatcher _canadaWatcher;
        private readonly FileSystemWatcher _warehouseExportWatcher;
        private readonly FileSystemWatcher _factoryDirectWatcher;
        private static bool _checkForAllBrands;
        
        public MarketingGeneratorService()
        {
            InitializeComponent();
            _watcher = new FileSystemWatcher
                        {
                            NotifyFilter = NotifyFilters.FileName,
                            Filter = "*.SND",
                            IncludeSubdirectories = false
                        };

            _canadaWatcher = new FileSystemWatcher
                        {
                            NotifyFilter = NotifyFilters.FileName,
                            Filter = "*.SND",
                            IncludeSubdirectories = false
                        };

            _warehouseExportWatcher = new FileSystemWatcher
                        {
                            NotifyFilter = NotifyFilters.FileName,
                            Filter = "*.SND",
                            IncludeSubdirectories = false
                        };

            _factoryDirectWatcher = new FileSystemWatcher
                        {
                            NotifyFilter = NotifyFilters.FileName,
                            Filter = "*.SND",
                            IncludeSubdirectories = false
                        };
        }

        protected override void OnStart(string[] args)
        {
            // US watcher
            _watcher.Path = "D:\\WolverineDirect\\US";
            _watcher.Renamed += FileSystemWatcher_Created;
            _watcher.EnableRaisingEvents = true;

            // Canada watcher
            _canadaWatcher.Path = "D:\\WolverineDirect\\Canada";
            _canadaWatcher.Renamed += CanadaFileSystemWatcher_Created;
            _canadaWatcher.EnableRaisingEvents = true;

            // Warehouse Export watcher
            _warehouseExportWatcher.Path = "D:\\WolverineDirect\\WarehouseExport";
            _warehouseExportWatcher.Renamed += WarehouseExportFileSystemWatcher_Created;
            _warehouseExportWatcher.EnableRaisingEvents = true;

            // Factory Direct watcher
            _factoryDirectWatcher.Path = "D:\\WolverineDirect\\FactoryDirect";
            _factoryDirectWatcher.Renamed += FactoryDirectFileSystemWatcher_Created;
            _factoryDirectWatcher.EnableRaisingEvents = true;

            _checkForAllBrands = ConfigurationManager.AppSettings["CheckBrands"] == "true";
        }

        /// <summary>
        /// Service watches folder for US integration files.
        /// </summary>
        protected void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            ReadAndGenerateFiles(e, "US");
        }

        /// <summary>
        /// Service watches folder for Canada integration files.
        /// </summary>
        protected void CanadaFileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            ReadAndGenerateFiles(e, "CA");
        }

        /// <summary>
        /// Service watches folder for Warehouse Export international integration files.
        /// </summary>
        protected void WarehouseExportFileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            ReadAndGenerateFiles(e, "WE");
        }

        /// <summary>
        /// Service watches folder for Factory Direct international integration files.
        /// </summary>
        protected void FactoryDirectFileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            ReadAndGenerateFiles(e, "FD");
        }

        protected override void OnStop()
        {
            _watcher.EnableRaisingEvents = false;
            _canadaWatcher.EnableRaisingEvents = false;
            _warehouseExportWatcher.EnableRaisingEvents = false;
            _factoryDirectWatcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Reads excel files and SAP generated product data from ITE file.
        /// All excel files must be placed in the folder first then when RoboMon drops the rest
        /// of the files in and places the .SND file, all of the magic happens.
        /// </summary>
        /// <param name="e">File watcher triggers on the .Snd file</param>
        /// <param name="locale">2 char length abbreviation to separate country/location</param>
        private static void ReadAndGenerateFiles(FileSystemEventArgs e, string locale)
        {
            string path = e.FullPath.Substring(0, e.FullPath.LastIndexOf('\\'));

            if (e.Name.ToLower().EndsWith(".snd") && !string.IsNullOrEmpty(Directory.GetFiles(path).FirstOrDefault(f => f.ToLower().Contains(".snd"))))
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    // Check SAP files to make sure they haven't changed too greatly (which is most likely an error so we need to not send files)
                    if (ConfigurationManager.AppSettings["CheckSAPFiles"] == "true")
                    {
                        if (file.ToLower().EndsWith(".srm") || file.ToLower().EndsWith(".cus") ||
                            file.ToLower().EndsWith(".csr") || file.ToLower().EndsWith(".csh"))
                        {
                            CheckFileStatus(file);

                            Log.InfoFormat("Svc ({0}): Check SAP file integrity: {1}.", locale, file);
                            if (Generator.CheckSAPFileIsGood(file, locale))
                                Log.InfoFormat("Svc ({0}): File looks good.", locale);
                            else
                            {
                                Log.ErrorFormat("Svc ({0}): SAP linecount threshold exceeded. Did not send files for {0}. Deleting SAP files to prep for tomorrow's run and completing this locale's process.", locale);
                                CleanupFiles(path);
                                ProcessComplete(e, locale);
                                return;
                            }
                        }
                    }
                }
                
                // Needed to do this again because it goes through the files in alpha order -- want to check SAP files first
                // Also want to read HyTest first before other catalogs
                foreach (var file in Directory.GetFiles(path))
                {
                    if ((file.ToLower().EndsWith(".xls") || file.ToLower().EndsWith(".xlsm") || file.ToLower().EndsWith(".xlsx")) &&
                        file.ToLower().Contains("hytest"))
                    {
                        CheckFileStatus(file);

                        Log.InfoFormat("Svc ({0}): Begin reading spreadsheet: {1}.", locale, file);

                        string spreadsheetResults = Generator.ReadAndStoreData(file, locale);

                        Log.InfoFormat("Svc ({0}): {1} rows of marketing data inserted and {2} updated in database.",
                                       locale, spreadsheetResults.Split('_')[0], spreadsheetResults.Split('_')[1]);
                        Log.InfoFormat("Svc ({0}): {1} rows of flag data inserted and {2} updated in database.",
                                       locale, spreadsheetResults.Split('_')[2], spreadsheetResults.Split('_')[3]);
                        Log.InfoFormat("Svc ({0}): {1} rows of flag category data inserted and {2} updated in database.",
                                       locale, spreadsheetResults.Split('_')[4], spreadsheetResults.Split('_')[5]);
                    }
                }

                foreach (var file in Directory.GetFiles(path))
                {
                    if ((file.ToLower().EndsWith(".xls") || file.ToLower().EndsWith(".xlsm") || file.ToLower().EndsWith(".xlsx")) &&
                        !file.ToLower().Contains("hytest"))
                    {
                        CheckFileStatus(file);

                        Log.InfoFormat("Svc ({0}): Begin reading spreadsheet: {1}.", locale, file);

                        string spreadsheetResults = Generator.ReadAndStoreData(file, locale);

                        Log.InfoFormat("Svc ({0}): {1} rows of marketing data inserted and {2} updated in database.",
                                       locale, spreadsheetResults.Split('_')[0], spreadsheetResults.Split('_')[1]);
                        Log.InfoFormat("Svc ({0}): {1} rows of flag data inserted and {2} updated in database.",
                                       locale, spreadsheetResults.Split('_')[2], spreadsheetResults.Split('_')[3]);
                        Log.InfoFormat("Svc ({0}): {1} rows of flag category data inserted and {2} updated in database.",
                                       locale, spreadsheetResults.Split('_')[4], spreadsheetResults.Split('_')[5]);
                    }
                }

                try
                {
                    string itePath = Directory.GetFiles(path).FirstOrDefault(f => f.ToLower().EndsWith(".ite"));

                    if (!Generator.MarketingInfoTableHasData())
                    {
                        Log.ErrorFormat("Svc ({0}): No data present to compare \"{1}\" against. Deleting SAP files to prep for tomorrow's run and completing this locale's process.", locale, itePath);
                        CleanupFiles(path);
                        ProcessComplete(e, locale);
                        return;
                    }

                    CheckFileStatus(itePath);

                    Log.InfoFormat("Svc ({0}): Begin reading ITE file, \"{1}\", to look for exceptions.", locale, itePath);

                    string results = Generator.FilterByITE(itePath, locale, _checkForAllBrands);
                    if (results == "break")
                    {
                        Log.ErrorFormat("Svc ({0}): ITE was missing brand(s). Did not send files for {0}. Deleting SAP files to prep for tomorrow's run and completing this locale's process.",
                            locale);

                        CleanupFiles(path);
                        ProcessComplete(e, locale);
                        return;
                    }
                    var exceptions = results.Split('_');

                    Log.InfoFormat("Svc ({0}): {1} exceptions from {2} ITE items & {3} marketing items.",
                                   locale, exceptions[0], exceptions[1], exceptions[2]);
                    Log.InfoFormat("Svc ({0}): {1} exceptions from {2} flag info items.", locale, exceptions[3],
                                   exceptions[4]);
                    Log.InfoFormat("Svc ({0}): {1} exceptions from {2} flag category items.", locale, exceptions[5],
                                   exceptions[6]);
                }
                catch (Exception)
                {
                    Log.ErrorFormat("Svc {0}: Looks like the ITE file may be missing. Deleting any other SAP files and moving on.", locale);
                    CleanupFiles(path);
                    ProcessComplete(e, locale);
                    return;
                }
                

                // Create all files for iCongo now that the data is filtered against the ITE
                CreateFiles(path, locale);

                if (ConfigurationManager.AppSettings["GenerateImages"] == "true")
                    Generator.CreateImages(path + "\\Images\\", "90", "png", "0000", "00", locale);

                // Clear and backup marketing / flag data by locale in prep for next round of files
                Generator.ClearData(locale, true);

                if (ConfigurationManager.AppSettings["FTPFiles"] == "true")
                {
                    Log.InfoFormat("Svc ({0}): Files generated. Data cleared. Begin upload.", locale);

                    if (locale == "US" && ConfigurationManager.AppSettings["FTPToAppropos"] == "true")
                        UploadFilesToAppropos(path);

                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["iCongoUser"],
                                                                   ConfigurationManager.AppSettings["iCongoPass"]);

                        // Upload SAP generated files placed in folder
                        int sapFilesCount = 0;
                        foreach (var file in Directory.GetFiles(path))
                        {
                            if (SAPFile(file))
                            {
                                Log.InfoFormat("Svc ({0}): Uploading file: \"{1}\"", locale, file);

                                // Try to upload the file 5 times if unsuccessful
                                for (int i = 0; i < 6; i++)
                                {
                                    // We've tried enough. Something is wrong with the FTP. Halt this process.
                                    if (i == 5)
                                    {
                                        Log.ErrorFormat("Svc ({0}): FTP is down. Did not send all files for {0}. Deleting SAP files to prep for tomorrow's run and moving on to next locale.", locale);

                                        CleanupFiles(path);
                                        ProcessComplete(e, locale);
                                        return;
                                    }
                                    
                                    // Try to upload the file. Delete it when successful.
                                    if (Upload(client, ConfigurationManager.AppSettings["iCongoFTP" + locale], file))
                                    {
                                        File.Delete(file);
                                        Log.InfoFormat("Svc ({0}): \"{1}\" Uploaded. Deleting.", locale, file);
                                        sapFilesCount++;
                                        break;
                                    }

                                    Log.InfoFormat("Svc ({0}): \"{1}\" upload unsuccessful. Will try again.", locale, file);
                                }
                            }
                        }

                        Log.InfoFormat("Svc ({0}): Uploaded {1} SAP files.", locale, sapFilesCount);
                        if (sapFilesCount < 13 || sapFilesCount > 14)
                            Log.ErrorFormat("Svc ({0}): Uploaded {1} SAP files. Should have been 13 (14 if FD).", locale, sapFilesCount);

                        // Upload generated marketing files -- only ones in this folder
                        int marketingFilesCount = 0;
                        foreach (var file in Directory.GetFiles(path + "\\GeneratedFiles\\"))
                        {
                            Log.InfoFormat("Svc ({0}): Uploading file: \"{1}\"", locale, file);

                            if (Upload(client, ConfigurationManager.AppSettings["iCongoFTP" + locale], file))
                            {
                                string destFile = path + "\\Backup\\GeneratedFiles" + file.Substring(file.LastIndexOf('\\'));
                                try
                                {
                                    File.Copy(file, destFile, true);
                                    File.Delete(file);
                                }
                                catch (Exception ex)
                                {
                                    Log.ErrorFormat("Svc ({0}): Error moving file \"{1}\". Exception: {2}", locale, file, ex.Message);
                                }

                                Log.InfoFormat("Svc ({0}): \"{1}\" Uploaded. Moving to backup folder.", locale, file);
                                marketingFilesCount++;
                            }
                        }

                        Log.InfoFormat("Svc ({0}): Uploaded {1} marketing files.", locale, marketingFilesCount);

                        // Upload images
                        int imagesCount = 0;
                        if (Directory.Exists(path + "\\Images\\"))
                        {
                            foreach (var file in Directory.GetFiles(path + "\\Images\\"))
                            {
                                if (file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg"))
                                {
                                    Log.InfoFormat("Svc ({0}): Uploading file: \"{1}\"", locale, file);
                                    if (Upload(client, ConfigurationManager.AppSettings["iCongoImagesFTP" + locale], file))
                                    {
                                        string destFile = path + "\\Backup\\Images" + file.Substring(file.LastIndexOf('\\'));
                                        try
                                        {
                                            File.Copy(file, destFile, true);
                                            File.Delete(file);
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.ErrorFormat("Svc ({0}): Error moving file \"{1}\". Exception: {2}", locale, file, ex.Message);
                                        }

                                        Log.InfoFormat("Svc ({0}): \"{1}\" Uploaded. Moving to backup folder.", locale, file);
                                        imagesCount++;
                                    }
                                }
                            }
                        }

                        if (ConfigurationManager.AppSettings["GenerateImages"] == "true")
                            Log.InfoFormat("Svc ({0}): Uploaded {1} images.", locale, imagesCount);
                        else
                            Log.InfoFormat("Svc ({0}): Image generation/upload disabled. Skipping.", locale);
                    }
                }
                else
                {
                    Log.InfoFormat("Svc ({0}): Files generated. Data cleared. Upload is disabled. Process complete.", locale);
                }

                ProcessComplete(e, locale);
            }
        }

        /// <summary>
        /// Check if the file matches the suffix of the generated SAP files.
        /// </summary>
        /// <param name="file">File to check.</param>
        /// <returns>True if the file is a SAP file.</returns>
        private static bool SAPFile(string file)
        {
            return file.ToLower().EndsWith(".cat") || file.ToLower().EndsWith(".catitm") ||
                   file.ToLower().EndsWith(".clr") || file.ToLower().EndsWith(".con") ||
                   file.ToLower().EndsWith(".cse") || file.ToLower().EndsWith(".csh") || 
                   file.ToLower().EndsWith(".csr") || file.ToLower().EndsWith(".cus") ||
                   file.ToLower().EndsWith(".ite") || file.ToLower().EndsWith(".mgr") ||
                   file.ToLower().EndsWith(".scl") || file.ToLower().EndsWith(".srm") ||
                   file.ToLower().EndsWith(".upc") || file.ToLower().EndsWith(".csp");
        }

        /// <summary>
        /// Delete SAP files from the folder because something went wrong.
        /// </summary>
        private static void CleanupFiles(string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                if (SAPFile(file))
                {
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// Rename the RoboMon file to let it know the process is complete.
        /// </summary>
        private static void ProcessComplete(FileSystemEventArgs e, string locale)
        {
            switch (locale)
            {
                case "US":
                    File.Move(e.FullPath, e.FullPath.Substring(0, e.FullPath.LastIndexOf('\\')) + "\\IC1.DON");
                    break;
                case "CA":
                    File.Move(e.FullPath, e.FullPath.Substring(0, e.FullPath.LastIndexOf('\\')) + "\\IC2.DON");
                    break;
                case "WE":
                    File.Move(e.FullPath, e.FullPath.Substring(0, e.FullPath.LastIndexOf('\\')) + "\\IC3.DON");
                    break;
                case "FD":
                    File.Move(e.FullPath, e.FullPath.Substring(0, e.FullPath.LastIndexOf('\\')) + "\\IC4.DON");
                    break;
            }
        }

        /// <summary>
        /// Generate marketing files for iCongo.
        /// </summary>
        private static void CreateFiles(string path, string locale)
        {
            string filePath = path + "\\GeneratedFiles\\";

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            
            string fileName = string.Format("WWW{0}.MKT", DateTime.Today.ToString("yyyyMMdd"));
            Generator.CreateMarketingInfoFile(filePath + fileName, "mMkt", true, locale);
            fileName = string.Format("WWW{0}.FLG", DateTime.Today.ToString("yyyyMMdd"));
            Generator.CreateFlgFile(filePath + fileName, locale);
            fileName = string.Format("WWW{0}.FLC", DateTime.Today.ToString("yyyyMMdd"));
            Generator.CreateFlcFile(filePath + fileName, locale);
            fileName = string.Format("WWW{0}.FSA", DateTime.Today.ToString("yyyyMMdd"));
            Generator.CreateFsaFile(filePath + fileName, locale);
        }

        /// <summary>
        /// Check if a file can be opened and read.
        /// </summary>
        private static void CheckFileStatus(string path)
        {
            DateTime fileReceived = DateTime.Now;

            while (true)
            {
                if (FileUploadCompleted(path))
                {
                    break;
                }
                // Calculate the elapsed time and stop if the maximum retry period has been reached.
                TimeSpan timeElapsed = DateTime.Now - fileReceived;

                if (timeElapsed.TotalMinutes > 2)
                {
                    Log.ErrorFormat("The file \"{0}\" could not be processed.", path);
                    break;
                }
                System.Threading.Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// Check if the file can be opened for exclusive access which means that it is no longer locked by another process.
        /// </summary>
        private static bool FileUploadCompleted(string filename)
        {
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }

        /// <summary>
        /// Uploads a file to the specified FTP server.
        /// </summary>
        /// <param name="client">WebClient object complete with FTP credentials.</param>
        /// <param name="ftpServer">FTP server/path to send file.</param>
        /// <param name="filename">File to send.</param>
        /// <returns>True if successfully uploaded.</returns>
        private static bool Upload(WebClient client, string ftpServer, string filename)
        {
            try
            {
                CheckFileStatus(filename);
                // Upload the file - STOR overwrites if the file exists
                client.UploadFile(ftpServer + "/" + new FileInfo(filename).Name, "STOR", filename);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Svc ({0}): The file \"{0}\" could not be uploaded. Exception: {1}", filename, ex.Message);
                DeleteFromFTP(filename, ftpServer);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Upload files to Appropos.
        /// Appropos uses SFTP -- had to use a 3rd party plugin b/c .NET does not support SFTP natively
        /// </summary>
        /// <param name="path">Path where files to upload are located</param>
        private static void UploadFilesToAppropos(string path)
        {
            SshTransferProtocolBase sftp = new Sftp(ConfigurationManager.AppSettings["ApproposSFTP"],
                ConfigurationManager.AppSettings["ApproposUser"],
                ConfigurationManager.AppSettings["ApproposPass"]);

            try
            {
                Log.Info("Connecting to Appropos.");
                sftp.Connect(22);
                Log.Info("Connected.");

                string sftpPath = ConfigurationManager.AppSettings["ApproposPath"];

                foreach (var file in Directory.GetFiles(path))
                {
                    if ((SAPFile(file) || file.ToLower().EndsWith(".atp")) && !file.ToLower().EndsWith(".clr") &&
                        !file.ToLower().EndsWith(".con") && !file.ToLower().EndsWith(".csr") && !file.ToLower().EndsWith(".scl"))
                    {
                        CheckFileStatus(file);
                        sftp.Put(file, sftpPath + file.Substring(file.LastIndexOf('\\') + 1));
                        Log.InfoFormat("Uploaded to Appropos: \"{0}\".", file);
                        // Only used for Appropos
                        if (file.ToLower().EndsWith(".atp"))
                            File.Delete(file);
                    }
                }

                foreach (var file in Directory.GetFiles(path + "\\GeneratedFiles\\"))
                {
                    CheckFileStatus(file);
                    sftp.Put(file, sftpPath + file.Substring(file.LastIndexOf('\\') + 1));
                    Log.InfoFormat("Uploaded to Appropos: \"{0}\".", file);
                }

                // Create a "done" file for Appropos
                string fileName = string.Format("WWW{0}.DON", DateTime.Today.ToString("yyyyMMdd"));
                using (FileStream fs = File.Create(path + "\\" + fileName)) { }
                Log.Info("Uploaded files to Appropos. Sending 'DON' file.");
                CheckFileStatus(path + "\\" + fileName);
                sftp.Put(path + "\\" + fileName, sftpPath + fileName);
                File.Delete(path + "\\" + fileName);

                sftpPath = ConfigurationManager.AppSettings["ApproposPath"] + "resources/";

                foreach (var file in Directory.GetFiles(path + "\\Images\\"))
                {
                    // Only want to upload Merrell pics (footwear & apparel)
                    if ((file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg")) && file.Substring(file.LastIndexOf('\\') + 1).StartsWith("J"))
                    {
                        sftp.Put(file, sftpPath + file.Substring(file.LastIndexOf('\\') + 1));
                        Log.InfoFormat("Image uploaded to Appropos: \"{0}\".", file);
                    }
                }

                Log.Info("Finished uploading files to Appropos.");

                sftp.Close();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error uploading files to Appropos. Exception: {0}", ex.Message);
                sftp.Close();
            }
        }

        /// <summary>
        /// Deletes a file from the specified FTP server.
        /// </summary>
        /// <param name="filename">File to delete.</param>
        /// <param name="ftpServer">Path to FTP server.</param>
        private static void DeleteFromFTP(string filename, string ftpServer)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(ftpServer + "/" + new FileInfo(filename).Name);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                var response = (FtpWebResponse)request.GetResponse();
                Log.InfoFormat("Delete status: {0}", response.StatusDescription);
                response.Close();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error removing file from FTP. Exception: {0}", ex.Message);
            }
        }
    }
}
