using System;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using MarketingGenerator.Core;

namespace MarketingGenerator.App
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {
            // Directions & help
            if (args.Length == 0 || args.Any(arg => arg.Equals("-?")) || args.Any(arg => arg.Equals("?")))
            {
                Console.WriteLine("Directions: Specify a folder containing spreadsheets that adhere to the following: a sheet " +
                    "named '7 - Combined Data' which contains any of the following columns: 'Style' (required, unique), 'SO', 'DC', " +
                    "'Marketing Description', 'Marketing Description (FR)', 'Keywords', 'Size Run', " +
                    "'Cat1', 'Cat2', 'Cat3', 'Cat4', 'Cat1 (FR)', 'Cat2 (FR)', 'Cat3 (FR)', and 'Cat4 (FR)'.");
                Console.WriteLine();
                Console.WriteLine("List of arguments:");
                Console.WriteLine();
                Console.WriteLine("   -import=<path to folder containing excel files> -- eg. -import=C:\\Excel");
                Console.WriteLine("   -images=<path to save images> -- Create images from stock numbers in db");
                Console.WriteLine("   -create=<file type to create> -- File types:\r\n\t" +
                                  "mCsv -- Marketing info in CSV format\r\n\tmMkt -- Marketing info in MKT format\r\n\t" +
                                  "fFlg -- Flag info in FLG format\r\n\tfFlc -- Flag info in FLC format\r\n\t" +
                                  "fFsa -- Flag info in FSA format\r\n\teg. -create=mCsv to generate a CSV file with marketing info");
                Console.WriteLine();
                Console.WriteLine("Do you wish to execute the read of spreadsheet data in the current folder where the app resides? (y or n)");

                if (Console.ReadLine() == "y")
                {
                    ReadFilesAndStoreData(Directory.GetCurrentDirectory());
                }
            }
            
            if (args.Any(arg => arg.StartsWith("-path=")))
            {
                ReadFilesAndStoreData(args.FirstOrDefault(arg => arg.StartsWith("-path")).Split('=')[1]);
            }

            if (args.Any(arg => arg.StartsWith("-images=")))
            {
                SaveImages(args.FirstOrDefault(arg => arg.StartsWith("-images")).Split('=')[1]);
            }

            if (args.Any(arg => arg.StartsWith("-create=")))
            {
                CreateFile(args.FirstOrDefault(arg => arg.StartsWith("-create")).Split('=')[1]);
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.Read();
        }

        private static void ReadFilesAndStoreData(string path) 
        {
            Console.WriteLine("Reading files from path: " + path);
            Console.WriteLine();

            var dir = new DirectoryInfo(path);
            Console.WriteLine("File Name                       Size        Creation Date and Time");
            Console.WriteLine("==================================================================");
                
            foreach (var file in dir.GetFiles())
            {
                if (file.Name.EndsWith("xls") || file.Name.EndsWith("xlsx") || file.Name.EndsWith("xlsm"))
                {
                    Console.WriteLine("{0, -30:g} {1,-12:N0} {2} ", file.Name, file.Length, file.CreationTime);

                    Log.InfoFormat("App: Begin reading spreadsheet: {0}.", file.Name);

                    string numbers = Generator.ReadAndStoreData(file.FullName, "US");

                    Log.InfoFormat("App: {0} rows of marketing data inserted and {1} updated in database.", numbers.Split('_')[0], numbers.Split('_')[1]);
                    Log.InfoFormat("App: {0} rows of flag data inserted and {1} updated in database.", numbers.Split('_')[2], numbers.Split('_')[3]);
                    Log.InfoFormat("App: {0} rows of flag category data inserted and {1} updated in database.", numbers.Split('_')[4], numbers.Split('_')[5]);

                    Console.WriteLine();
                    Console.WriteLine(string.Format("{0} rows of marketing data inserted and {1} updated in database.\r\n" +
                                                    "{2} rows of flag data inserted and {3} updated in database.\r\n" +
                                                    "{4} rows of flag category inserted and {5} updated in database.",
                                                    numbers.Split('_')[0], numbers.Split('_')[1], numbers.Split('_')[2], numbers.Split('_')[3],
                                                    numbers.Split('_')[4], numbers.Split('_')[5]));
                }
            }
        }

        private static void SaveImages(string savePath)
        {
            Generator.CreateImages(savePath, "90", "png", "0000", "00", "US");
        }

        private static void CreateFile(string fileType)
        {
            const string filePath = "GeneratedFiles\\";
            string fileName;
            
            switch (fileType.ToLower())
            {
                case "mcsv":
                case "mmkt":
                    fileName = fileType.ToLower() == "mmkt"
                        ? string.Format("WWW{0}.MKT", DateTime.Today.ToString("yyyyMMdd"))
                        : string.Format("WWW{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                    Generator.CreateMarketingInfoFile(filePath + fileName, fileType, true, "US");
                    break;
                case "fflg":
                    fileName = string.Format("WWW{0}.FLG", DateTime.Today.ToString("yyyyMMdd"));
                    Generator.CreateFlgFile(filePath + fileName, "US");
                    break;
                case "fflc":
                    fileName = string.Format("WWW{0}.FLC", DateTime.Today.ToString("yyyyMMdd"));
                    Generator.CreateFlgFile(filePath + fileName, "US");
                    break;
                case "ffsa":
                    fileName = string.Format("WWW{0}.FSA", DateTime.Today.ToString("yyyyMMdd"));
                    Generator.CreateFsaFile(filePath + fileName, "US");
                    break;
            }
        }
    }
}
