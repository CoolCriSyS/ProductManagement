using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace BrokenImageFinder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRun_OnCommand(object sender, CommandEventArgs e)
        {
            CheckImages();
        }

        public DataTable ExecuteOracle()
        {
            var connection = new OracleConnection(System.Configuration.ConfigurationManager.AppSettings["DataConnOracle"]);
            using (connection)
            {
                var imageInfo = new DataTable();

                try
                {
                    connection.Open();
                    var selectCommand = new OracleCommand
                    {
                        Connection = connection,
                        CommandText =
                            @"SELECT b.brandname, mediaid, medianame, originalfilename, 
                                mediastoragepath, repwebimagepath, m.createdby, 
                                p1.lastname AS createdbyname, m.createdat, 
                                editedby, p2.lastname AS editedbyname, editedat
                              FROM cql_owner.media m
                                INNER JOIN cql_owner.brand b
                                    on m.brandid = b.brandid
                                INNER JOIN cql_owner.person p1
                                    on m.createdby = p1.personid
                                LEFT OUTER JOIN cql_owner.person p2
                                    on m.editedby = p2.personid"
                    };

                    var oracleDataAdapter = new OracleDataAdapter(selectCommand);
                    oracleDataAdapter.Fill(imageInfo);

                    return imageInfo;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }
            }
        }

        public void CheckImages()
        {
            string root = System.Configuration.ConfigurationManager.AppSettings["InternalPath"];
            var imagesCount = 0;
            var notFoundCount = 0;

            string foundPathMedia = Server.MapPath("Images/FoundMediaStorage.csv");
            string notFoundPathMedia = Server.MapPath("Images/NotFoundMediaStorage.csv");
            string foundPathWebImage = Server.MapPath("Images/FoundWebImages.csv");
            string notFoundPathWebImage = Server.MapPath("Images/NotFoundWebImages.csv");
            
            var imageData = ExecuteOracle();

            foreach (DataRow row in imageData.Rows)
            {
                string path = row["mediastoragepath"].ToString().Replace('/', '\\');

                if (!string.IsNullOrEmpty(path))
                {
                    // Found
                    if (File.Exists(root + path))
                    {
                        using (var streamWriter = new StreamWriter(foundPathMedia, true, System.Text.Encoding.UTF8))
                        {
                            int iColCount = imageData.Columns.Count;

                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(row[i]))
                                {
                                    streamWriter.Write(row[i].ToString());
                                }

                                if (i < iColCount - 1)
                                {
                                    streamWriter.Write(",");
                                }
                            }

                            streamWriter.Write(streamWriter.NewLine);
                        }
                        imagesCount++;
                    }
                    // Not found
                    else
                    {
                        using (var streamWriter = new StreamWriter(notFoundPathMedia, true, System.Text.Encoding.UTF8))
                        {
                            int iColCount = imageData.Columns.Count;

                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(row[i]))
                                {
                                    streamWriter.Write(row[i].ToString());
                                }

                                if (i < iColCount - 1)
                                {
                                    streamWriter.Write(",");
                                }
                            }

                            streamWriter.Write(streamWriter.NewLine);
                        }
                        notFoundCount++;
                    }
                }
                else // No path was found
                {
                    //TODO: What to do?
                }

                // Do it again for web image path
                path = row["repwebimagepath"].ToString().Replace('/', '\\');

                if (!string.IsNullOrEmpty(path))
                {
                    // Found
                    if (File.Exists(root + path))
                    {
                        using (var streamWriter = new StreamWriter(foundPathWebImage, true, System.Text.Encoding.UTF8))
                        {
                            int iColCount = imageData.Columns.Count;

                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(row[i]))
                                {
                                    streamWriter.Write(row[i].ToString());
                                }

                                if (i < iColCount - 1)
                                {
                                    streamWriter.Write(",");
                                }
                            }

                            streamWriter.Write(streamWriter.NewLine);
                        }
                        imagesCount++;
                    }
                    // Not found
                    else
                    {
                        using (var streamWriter = new StreamWriter(notFoundPathWebImage, true, System.Text.Encoding.UTF8))
                        {
                            int iColCount = imageData.Columns.Count;

                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(row[i]))
                                {
                                    streamWriter.Write(row[i].ToString());
                                }

                                if (i < iColCount - 1)
                                {
                                    streamWriter.Write(",");
                                }
                            }

                            streamWriter.Write(streamWriter.NewLine);
                        }
                        notFoundCount++;
                    }
                }
                else // No path was found
                {
                    //TODO: What to do?
                }
            }
        }

        private static byte[] GetBytesFromUrl(string url)
        {
            byte[] bytes;

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
            finally
            {
                fileStream.Close();
                binaryWriter.Close();
            }
        }
    }
}
