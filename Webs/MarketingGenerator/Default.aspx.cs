using System;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MarketingGenerator.Core;
using MarketingGenerator.Core.DbObjects;

namespace MarketingGenerator
{
    public partial class Default : Page
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const string LOREMIPSUM_EN = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris egestas diam sit amet quam vulputate tempor. Proin vel egestas neque. Curabitur malesuada orci id sapien blandit nec porttitor dolor euismod. Aenean a convallis nisl. Morbi metus lacus, aliquam condimentum vestibulum vel, dignissim eget erat. Aenean lacus felis, ultrices eget interdum sit amet, fringilla ac odio. Nulla sapien neque, pellentesque a euismod quis, euismod id metus. Nam adipiscing sem at sapien eleifend commodo. Quisque hendrerit pretium tincidunt. Praesent tempor urna et erat laoreet quis feugiat felis porta. Mauris lectus ante, iaculis vel aliquet non, malesuada sed nulla. Vestibulum semper est nec nisi dignissim vel eleifend tortor suscipit. Ut vulputate, magna posuere faucibus condimentum, velit nunc dictum augue, et sodales dolor tellus eget sapien. Nunc ac porttitor diam. Maecenas porttitor arcu at ipsum adipiscing quis suscipit metus fringilla. Quisque porttitor odio ac libero scelerisque mollis. Suspendisse lacinia nisi non nibh malesuada faucibus. Cras et ligula id nisl lacinia faucibus pretium id tortor. Suspendisse cursus risus et metus pulvinar ac eleifend arcu egestas.";
        private const string LOREMIPSUM_FR = @"Cras luctus justo eu velit consequat dapibus dapibus a dolor. Ut facilisis turpis vitae dui semper id euismod eros porttitor. Donec et pellentesque neque. Integer mauris est, fermentum quis iaculis sit amet, accumsan sed diam. In id massa sed libero fringilla suscipit ut ac mauris. Sed rutrum metus condimentum dolor pulvinar vulputate. Cras erat ipsum, sodales quis lobortis et, mollis non massa. Duis est metus, egestas ac bibendum eu, blandit in ligula. Pellentesque at tellus leo, non vehicula lorem. Sed ac eros ante. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ac risus nulla. Maecenas tincidunt semper luctus. Morbi ultricies vehicula malesuada. Nulla vitae orci urna, sed viverra mauris. Donec non mauris id nisi venenatis consequat. Aenean ligula ligula, vestibulum id varius eu, pharetra id sem.";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Generator.MarketingInfoTableHasData())
            {
                btnClearData.Enabled = true;
                btnClearData.Text = "Clear out existing data";
                cbBackup.Visible = true;
            }
            else
            {
                btnClearData.Enabled = false;
                btnClearData.Text = "No marketing info to clear";
                cbBackup.Visible = false;
            }
        }

        #region UI Events
        protected void btnUpload_OnCommand(object sender, CommandEventArgs e)
        {
            if (fuSpreadsheet.HasFile &&
                (fuSpreadsheet.FileName.ToLower().EndsWith("xls") || fuSpreadsheet.FileName.ToLower().EndsWith("xlsx") 
                    || fuSpreadsheet.FileName.ToLower().EndsWith("xlsm")))
            {
                Log.InfoFormat("Web: Begin reading spreadsheet: {0}.", fuSpreadsheet.FileName);
                
                // Had issues with reading the file -- need to save it server-side temporarily
                fuSpreadsheet.SaveAs(Server.MapPath(fuSpreadsheet.FileName));

                string results = Generator.ReadAndStoreData(Server.MapPath(fuSpreadsheet.FileName), "US");
                
                File.Delete(Server.MapPath(fuSpreadsheet.FileName)); // Done with temp excel file

                Log.InfoFormat("Web: {0} rows of marketing data inserted and {1} updated in database.", results.Split('_')[0], results.Split('_')[1]);
                Log.InfoFormat("Web: {0} rows of flag data inserted and {1} updated in database.", results.Split('_')[2], results.Split('_')[3]);
                Log.InfoFormat("Web: {0} rows of flag category data inserted and {1} updated in database.", results.Split('_')[4], results.Split('_')[5]);

                lblSuccess.Visible = true;
                lblSuccess.Text = string.Format("{0} rows of marketing data inserted and {1} updated in database.<br />" + 
                                                "{2} rows of flag data inserted and {3} updated in database.<br />" +
                                                "{4} rows of flag category data inserted and {5} updated in database.",
                                                results.Split('_')[0], results.Split('_')[1], results.Split('_')[2], results.Split('_')[3],
                                                results.Split('_')[4], results.Split('_')[5]);

                btnClearData.Enabled = true;
                btnClearData.Text = "Clear out existing data";
                cbBackup.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please upload a spreadsheet ending in 'xls', 'xlsx', or 'xlsm'";
            }
        }

        protected void btnClearData_OnCommand(object sender, CommandEventArgs e)
        {
            Generator.ClearData("US", cbBackup.Checked);

            btnClearData.Enabled = false;
            btnClearData.Text = "Data cleared";
            cbBackup.Visible = false;

            lblSuccess.Visible = false;
            lblError.Visible = false;
        }

        protected void btnCreateFiles_OnCommand(object sender, CommandEventArgs e)
        {
            switch (ddlFiles.SelectedValue)
            {
                case "mCsv":
                case "mMkt":
                    SaveMarketingInfoFile();
                    break;
                case "fFlg":
                    SaveFlgFile();
                    break;
                case "fFlc":
                    SaveFlcFile();
                    break;
                case "fFsa":
                    SaveFsaFile();
                    break;
            }
            
            Log.Info("File generated successfully.");
            lblSuccess.Text = "File was created successfully";
        }

        protected void btnUploadITE_OnCommand(object sender, CommandEventArgs e)
        {
            if (fuITE.HasFile && fuITE.FileName.ToLower().EndsWith("ite"))
            {
                Log.InfoFormat("Web: Begin reading ITE file, {0}, to look for exceptions.", fuITE.FileName);

                fuITE.SaveAs(Server.MapPath(fuITE.FileName));
                string results = Generator.FilterByITE(Server.MapPath(fuITE.FileName), "US", false);
                File.Delete(Server.MapPath(fuITE.FileName));

                Log.InfoFormat("Web: {0} exceptions from {1} ITE items & {2} marketing items.",
                    results.Split('_')[0], results.Split('_')[1], results.Split('_')[2]);
                Log.InfoFormat("Web: {0} exceptions from {1} flag info items.", results.Split('_')[3], results.Split('_')[4]);
                Log.InfoFormat("Web: {0} exceptions from {1} flag category items.", results.Split('_')[5], results.Split('_')[6]);

                lblError.Visible = true;
                lblError.Text = string.Format("{0} exceptions from {1} ITE items & {2} marketing items.<br />" +
                                              "{3} exceptions from {4} flag info items.<br />" +
                                              "{5} exceptions from {6} flag category items.",
                        results.Split('_')[0], results.Split('_')[1], results.Split('_')[2],
                        results.Split('_')[3], results.Split('_')[4], results.Split('_')[5], results.Split('_')[6]);
                lblSuccess.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please upload an ITE file";
            }
        }

        protected void btnXmlUpload_OnCommand(object sender, CommandEventArgs e)
        {
            if (fuB2CXmlData.HasFile && fuB2CXmlData.FileName.ToLower().EndsWith("xml"))
            {
                fuB2CXmlData.SaveAs(Server.MapPath(fuB2CXmlData.FileName));
                string results = Generator.ParseXmlForB2CData(Server.MapPath(fuB2CXmlData.FileName));
                File.Delete(Server.MapPath(fuB2CXmlData.FileName));

                if (string.IsNullOrEmpty(results))
                {
                    Log.InfoFormat("Web: No data read from file: {0}", fuB2CXmlData.FileName);
                    lblError.Visible = true;
                    lblError.Text = "No data read from XML file";
                    return;
                }

                Log.InfoFormat(string.Format(@"Web: Process of importing {0} pattern(s) [{1} style(s)] completed successfully. 
                        {2} style(s) were imported. {3} style(s) were not imported due to being duplicate. 
                        {4} existing style(s) were updated with french description. 
                        {5} style(s) were not imported due to Style Number greater than 18 characters.",
                    results.Split('_')[0], results.Split('_')[1], results.Split('_')[2], results.Split('_')[3],
                    results.Split('_')[4], results.Split('_')[5]));

                lblSuccess.Visible = true;
                lblSuccess.Text = string.Format("Process of importing {0} pattern(s) [{1} style(s)] completed successfully.<br />" +
                        "{2} style(s) were imported. {3} style(s) were not imported due to being duplicate.<br />" +
                        "{4} existing style(s) were updated with french description.<br />" +
                        "{5} style(s) were not imported due to Style Number greater than 18 characters.",
                    results.Split('_')[0], results.Split('_')[1], results.Split('_')[2], results.Split('_')[3],
                    results.Split('_')[4], results.Split('_')[5]);
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please upload a XML file";
            }
        }

        protected void btnGetImages_OnCommand(object sender, CommandEventArgs e)
        {
            string salesOrg = ddlGenerateImageBrand.SelectedItem.Value.Split('~')[0];
            string dc = ddlGenerateImageBrand.SelectedItem.Value.Split('~')[1];

            string results = Generator.CreateImages(Server.MapPath("Images/"), ddlQuality.SelectedValue, ddlType.SelectedValue, salesOrg, dc, "US");

            lblImageSuccess.Visible = true;
            lblImageSuccess.Text = String.Format("{0} image(s) successfully created out of {1} stock numbers.", 
                results.Split('_')[0], results.Split('_')[1]);
        }

        protected void btnRunB2CMarketingUpdate_Click(object sender, EventArgs e)
        {
            string salesOrg = ddlBrand.SelectedItem.Value.Split('~')[0];
            string dc = ddlBrand.SelectedItem.Value.Split('~')[1];
            DataTable marketingDataTable = new DataTable();
            //if cbForceB2C is checked then overwrite what's in the database with Marketing Info from B2C
            bool forceB2C = cbForceB2C.Checked;

            int countOfUpdatedEn = 0;
            int countOfUpdatedFr = 0;

            var db = new B2BProductCatalog();

            if (salesOrg == "0000" && dc == "00")
                //get all entries for selected SalesOrg, DistributtionChannel
                marketingDataTable = db.MarketingInfoCollection.GetAllAsDataTable();
            else
                marketingDataTable = db.MarketingInfoCollection.GetAsDataTable(
                    string.Format("SalesOrg='{0}' AND DistributionChannel='{1}'", salesOrg, dc), "");


            for (int i = 0; i < marketingDataTable.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(marketingDataTable.Rows[i]["MarketingDescEn"].ToString()) || forceB2C)
                {
                    var row = db.B2CProductDataCollection.GetByStyleNumber(marketingDataTable.Rows[i]["StyleNumber"].ToString());

                    if (row != null)
                        if (!string.IsNullOrEmpty(row.ProductDescEn))
                        {
                            marketingDataTable.Rows[i].BeginEdit();
                            marketingDataTable.Rows[i]["MarketingDescEn"] = row.ProductDescEn;
                            marketingDataTable.Rows[i].EndEdit();

                            countOfUpdatedEn++;
                        }
                }
                if (string.IsNullOrEmpty(marketingDataTable.Rows[i]["MarketingDescFr"].ToString()) || forceB2C)
                {
                    var row = db.B2CProductDataCollection.GetByStyleNumber(marketingDataTable.Rows[i]["StyleNumber"].ToString());

                    if (row != null)
                        if (!string.IsNullOrEmpty(row.ProductDescFr))
                        {
                            marketingDataTable.Rows[i].BeginEdit();
                            marketingDataTable.Rows[i]["MarketingDescFr"] = row.ProductDescFr;
                            marketingDataTable.Rows[i].EndEdit();

                            countOfUpdatedFr++;
                        }
                }
            }

            //try to run the update
            db.MarketingInfoCollection.Update(marketingDataTable);

            lblSuccess.Visible = true;
            lblSuccess.Text = string.Format("{0} styles updated with English and {1} styles updated with French marketing B2C description.",
                countOfUpdatedEn, countOfUpdatedFr);
        }

        protected void btnUpdateMarketingWithLoremIpsum_Click(object sender, EventArgs e)
        {
            int countOfUpdatedEn = 0;
            int countOfUpdatedFr = 0;
            var marketingDataTable = new DataTable();

            var db = new B2BProductCatalog();

            string salesOrg = ddlBrand.SelectedItem.Value.Split('~')[0];
            string dc = ddlBrand.SelectedItem.Value.Split('~')[1];

            if (salesOrg == "0000" && dc == "00")
                //get all entries for selected SalesOrg, DistributtionChannel
                marketingDataTable = db.MarketingInfoCollection.GetAllAsDataTable();
            else
                marketingDataTable = db.MarketingInfoCollection.GetAsDataTable(
                    string.Format("SalesOrg='{0}' AND DistributionChannel='{1}'", salesOrg, dc), "");

            for (int i = 0; i < marketingDataTable.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(marketingDataTable.Rows[i]["MarketingDescEn"].ToString()))
                {
                    marketingDataTable.Rows[i].BeginEdit();
                    marketingDataTable.Rows[i]["MarketingDescEn"] = LOREMIPSUM_EN;
                    marketingDataTable.Rows[i].EndEdit();

                    countOfUpdatedEn++;
                }
                if (string.IsNullOrEmpty(marketingDataTable.Rows[i]["MarketingDescFr"].ToString()))
                {
                    marketingDataTable.Rows[i].BeginEdit();
                    marketingDataTable.Rows[i]["MarketingDescFr"] = LOREMIPSUM_FR;
                    marketingDataTable.Rows[i].EndEdit();

                    countOfUpdatedFr++;
                }
            }

            //try to run the update
            db.MarketingInfoCollection.Update(marketingDataTable);

            lblSuccess.Visible = true;
            lblSuccess.Text = string.Format("{0} styles updated with English and {1} styles updated with French marketing Lorem Ipsum description.",
                countOfUpdatedEn, countOfUpdatedFr);
        }
        #endregion

        #region Create Files
        private void SaveMarketingInfoFile()
        {
            string fileName = ddlFiles.SelectedValue == "mMkt"
                ? string.Format("WWW{0}.MKT", DateTime.Today.ToString("yyyyMMdd"))
                : string.Format("WWW{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

            string filePath = Server.MapPath(fileName);

            Generator.CreateMarketingInfoFile(Server.MapPath(fileName), ddlFiles.SelectedValue, cbB2CData.Checked, "US");

            var response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain;charset=utf-8";
            response.ContentEncoding = System.Text.Encoding.GetEncoding(1252);
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(filePath);
            response.Flush();
            File.Delete(filePath);
            response.End();
        }

        private void SaveFlgFile()
        {
            string fileName = string.Format("WWW{0}.FLG", DateTime.Today.ToString("yyyyMMdd"));
            string filePath = Server.MapPath(fileName);

            Generator.CreateFlgFile(filePath, "US");

            var response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain;charset=utf-8";
            response.ContentEncoding = System.Text.Encoding.GetEncoding(1252);
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(filePath);
            response.Flush();
            File.Delete(filePath);
            response.End();
        }

        private void SaveFlcFile()
        {
            string fileName = string.Format("WWW{0}.FLC", DateTime.Today.ToString("yyyyMMdd"));
            string filePath = Server.MapPath(fileName);
            
            Generator.CreateFlcFile(filePath, "US");

            var response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain;charset=utf-8";
            response.ContentEncoding = System.Text.Encoding.GetEncoding(1252);
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(filePath);
            response.Flush();
            File.Delete(filePath);
            response.End();
        }

        private void SaveFsaFile()
        {
            string fileName = string.Format("WWW{0}.FSA", DateTime.Today.ToString("yyyyMMdd"));
            string filePath = Server.MapPath(fileName);

            Generator.CreateFsaFile(filePath, "US");

            var response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain;charset=utf-8";
            response.ContentEncoding = System.Text.Encoding.GetEncoding(1252);
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(filePath);
            response.Flush();
            File.Delete(filePath);
            response.End();
        }
        #endregion
    }
}