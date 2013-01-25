using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using log4net;

namespace ImageGenerator
{
    public partial class _Default : System.Web.UI.Page
    {
        private int _imagesCount;
        private int _notFoundCount;

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnUpload_OnCommand(object sender, CommandEventArgs e)
        {
            if (fuSpreadsheet.HasFile && (fuSpreadsheet.FileName.EndsWith("xls") || fuSpreadsheet.FileName.EndsWith("xlsx")))
            {
                // Had issues with reading the file -- need to save temporarily
                fuSpreadsheet.SaveAs(Server.MapPath("Images/" + fuSpreadsheet.FileName));
                Log.InfoFormat("Begin reading spreadsheet: {0}.", fuSpreadsheet.FileName);
                
                var stockNumbers = ReadSpreadsheet(Server.MapPath("Images/" + fuSpreadsheet.FileName));
                File.Delete(Server.MapPath("Images/" + fuSpreadsheet.FileName)); // Done with temp excel file

                string rootUrl = System.Configuration.ConfigurationManager.AppSettings["ImageRootUrl"];

                for (int i = 0; i < stockNumbers.Tables[0].Rows.Count; i++)
                {
                    var stockNumber = stockNumbers.Tables[0].Rows[i]["Style Number"].ToString();
                    var path = ExecuteOracle(stockNumber);

                    if (!string.IsNullOrEmpty(path))
                    {
                        var imageBytes = GetBytesFromUrl(String.Format("{0}{1}?cell=1000,1000&qlt={2}&cvt={3}", rootUrl, path,
                                                      ddlQuality.SelectedValue, ddlType.SelectedValue));

                        WriteBytesToFile(String.Format(Server.MapPath("Images/{0}.{1}"), stockNumber, ddlType.SelectedValue), imageBytes);
                        _imagesCount++;
                    }
                    else if (!string.IsNullOrEmpty(stockNumber))
                    {
                        string filePath = Server.MapPath("Images/_NotFound.txt");
                        txtNotFound.Text += stockNumber + Environment.NewLine;
                        _notFoundCount++;

                        if (File.Exists(filePath))
                        {
                            WriteBadStockNumbersToFile(filePath, stockNumber);
                        }
                        else
                        {
                            File.Create(filePath);
                            WriteBadStockNumbersToFile(filePath, stockNumber);
                        }
                    }
                }

                Log.Info("Completed successfully.");

                lblSuccess.Visible = true;
                lblSuccess.Text = String.Format("{0} image(s) successfully created", _imagesCount);

                if (_notFoundCount > 0)
                {
                    lblNotFound.Visible = true;
                    txtNotFound.Visible = true;
                    lblNotFound.Text = String.Format("{0} stock number(s) not found:", _notFoundCount);
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please upload a spreadsheet ending in 'xls' or 'xlsx'";
            }
        }

        private static DataSet ReadSpreadsheet(string fileName)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + @";Extended Properties=""Excel 12.0;HDR=YES;""";

            var factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            var adapter = factory.CreateDataAdapter();

            try
            {
                var selectCommand = factory.CreateCommand();
                selectCommand.CommandText = "SELECT [Style Number] FROM [5 - Styles and Catalog$]";

                var connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;
                selectCommand.Connection = connection;
                adapter.SelectCommand = selectCommand;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error reading spreadsheet. Exception: {0}.", ex.Message);
                throw;
            }

            var stockNumbers = new DataSet();
            adapter.Fill(stockNumbers);

            Log.Info(string.Format("{0} stock numbers read.", stockNumbers.Tables[0].Rows.Count));

            return stockNumbers;
        }

        private string ExecuteOracle(string stockNumber)
        {
            var connection = new OracleConnection(System.Configuration.ConfigurationManager.AppSettings["DataConnOracle"]);
            using (connection)
            {
                var imageInfo = new DataTable();

                try
                {
                    connection.Open();
                    //MediaTypeID (1- Web Product, 9 - Web Apparel)
                    var selectCommand = new OracleCommand
                              {
                                  Connection = connection,
                                  CommandText =
                                      @"SELECT m.mediaid, s.stocknumber, 
								                CASE WHEN f.filetype='EPS' THEN
									                NVL(m.repwebimagepath, m.mediastoragepath)
								                ELSE
									                m.mediastoragepath
								                END as IMAGELOC,
								                m.mediastoragepath, 
								                m.repwebimagepath,
								                m.isactive, m.createdat
						                FROM cql_owner.style s
						                INNER JOIN mediastyle ms
								                ON s.styleid=ms.styleid
						                INNER JOIN media m
								                ON ms.mediaid= m.mediaid
						                INNER JOIN filetype f
								                ON m.filetypeid=f.filetypeid
						                WHERE f.isimage = 1
								                AND m.mediastoragepath is not NULL
						                        AND s.stocknumber = '" + stockNumber + @"' 
								                AND m.mediatypeid IN (1,9)
						                ORDER BY s.stocknumber, m.isactive, m.createdat ASC"
                              };

                    var oracleDataAdapter = new OracleDataAdapter(selectCommand);
                    oracleDataAdapter.Fill(imageInfo);
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    Log.ErrorFormat("Error executing Oracle statement. Exception: {0}", ex.Message);
                    throw;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }

                if (imageInfo.Rows.Count > 0)
                    return imageInfo.Rows[0][2].ToString();

                return string.Empty;
            }
        }

        private static byte[] GetBytesFromUrl(string url)
        {
            byte[] bytes;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = request.GetResponse();

                var stream = response.GetResponseStream();
                using (var binaryReader = new BinaryReader(stream))
                {
                    bytes = binaryReader.ReadBytes(1000000);
                    binaryReader.Close();
                    stream.Flush();
                }
                response.Close();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error fetching image. Exception: {0}.", ex.Message);
                throw;
            }
            
            return bytes;
        }

        private static void WriteBytesToFile(string fileName, byte[] content)
        {
            var fileStream = new FileStream(fileName, FileMode.Create);
            var binaryWriter = new BinaryWriter(fileStream);

            try
            {
                binaryWriter.Write(content);
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("Error writing image. Exception: {0}.", ex.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
                binaryWriter.Close();
            }
        }

        private static void WriteBadStockNumbersToFile(string filePath, string stockNumber)
        {
            try
            {
                if (!File.ReadAllText(filePath).Contains(stockNumber))
                {
                    File.AppendAllText(filePath, stockNumber + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error with _NotFound.txt. Exception: {0}.", ex.Message);
                throw;
            }
        }
    }
}
