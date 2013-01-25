using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using log4net;
using MarketingGenerator.Core.DbObjects;
using Oracle.DataAccess.Client;

namespace MarketingGenerator.Core
{
    public class Generator
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string SalesOrg { get; set; }
        public static string DistChan { get; set; }
        
        /// <summary>
        /// Read spreadsheet data and store in the database.
        /// </summary>
        /// <param name="filePath">Path of excel file.</param>
        /// <returns>Counts of entries.</returns>
        public static string ReadAndStoreData(string filePath, string locale)
        {
            var marketingInfo = ReadSpreadsheet(filePath, "[7 - Combined Data$]");

            SalesOrg = marketingInfo.Rows[1]["SO"].ToString();
            DistChan = marketingInfo.Rows[1]["DC"].ToString();

            // Add flags first so we can get the FlagId into the MarketingInfo table
            string flagCount = AddFlagInfoToDb(ReadSpreadsheet(filePath, "[4 - Flags$]"),
                                               ReadSpreadsheet(filePath, "[3 - Flag Categories$]"), locale);

            string stylesCount = AddMarketingInfoToDb(marketingInfo, locale);

            return stylesCount + "_" + flagCount;
        }
        
        /// <summary>
        /// Reads all the spreadsheet data and puts it into a useable DataTable.
        /// </summary>
        /// <param name="filePath">Path to the spreadsheet.</param>
        /// <param name="spreadsheetPage">Page of the spreadsheet to read.</param>
        /// <returns>DataTable to easily use the data from the spreadsheet.</returns>
        public static DataTable ReadSpreadsheet(string filePath, string spreadsheetPage)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
                                      @";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""";

            var spreadsheetData = new DataSet();

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbDataAdapter adapter = factory.CreateDataAdapter())
            {
                try
                {
                    DbCommand selectCommand = factory.CreateCommand();
                    selectCommand.CommandText = "SELECT * FROM " + spreadsheetPage;

                    DbConnection connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                    selectCommand.Connection = connection;
                    adapter.SelectCommand = selectCommand;

                    adapter.Fill(spreadsheetData);

                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("Error reading spreadsheet. Exception: {0}.", ex.Message);
                }
            }

            return spreadsheetData.Tables[0];
        }

        /// <summary>
        /// Filters the current marketing and flag data in the database against the ITE file supplied.
        /// Note: All of the exception tables' UpdatedOn fields contain current time for ease of search.
        /// </summary>
        /// <param name="filepath">Path to ITE file.</param>
        /// <returns>Numbers of exceptions.</returns>
        public static string FilterByITE(string filepath, string locale, bool checkForAllBrands)
        {
            var iteTable = new DataTable("ITETable");
            var dataColumn = iteTable.Columns.Add("StyleNumber", typeof(string));
            dataColumn.MaxLength = 18;
            dataColumn = iteTable.Columns.Add("SalesOrg", typeof(string));
            dataColumn.MaxLength = 4;
            dataColumn = iteTable.Columns.Add("DistributionChannel", typeof(string));
            dataColumn.MaxLength = 2;

            try
            {
                using (var streamReader = new StreamReader(filepath, Encoding.UTF8))
                {
                    iteTable.BeginLoadData();
                    var values = new object[3];

                    while (streamReader.Peek() != -1)
                    {
                        string line = streamReader.ReadLine();

                        if (!string.IsNullOrEmpty(line))
                        {
                            var sections = line.Split('|');

                            values[0] = sections[1]; // StyleNumber
                            values[1] = sections[29]; // SalesOrg
                            values[2] = sections[27]; // DistChan

                            iteTable.LoadDataRow(values, true);
                        }
                    }
                    iteTable.EndLoadData();
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error when reading ITE. Exception: {0}", ex.Message);
                throw;
            }

            if (checkForAllBrands)
            {
                try
                {
                    if (!ITEContainsAllBrands(iteTable, locale))
                    {
                        // ITE is missing a brand. Wipe data and move on to next locale.
                        ClearData(locale, false);
                        return "break";
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("Error when checking ITE for all brands. Exception: {0}", ex.Message);
                    return "break";
                }
            }

            var db = new B2BProductCatalog();
            DataTable marketingDataTable = db.MarketingInfoCollection.GetAllByLocale(locale);

            // Remove marketing info that is not in ITE file and move to exceptions table
            var exceptionsRows = (from DataRow marketingRow in marketingDataTable.Rows
                                  where !iteTable.Rows.Cast<DataRow>()
                                    .Any(iteRow => iteRow["StyleNumber"].ToString() == marketingRow["StyleNumber"].ToString() &&
                                        iteRow["SalesOrg"].ToString() == marketingRow["SalesOrg"].ToString() &&
                                        iteRow["DistributionChannel"].ToString() == marketingRow["DistributionChannel"].ToString())
                                  select new MarketingInfo_ExceptionsRow
                                  {
                                      StyleNumber = marketingRow["StyleNumber"].ToString(),
                                      SalesOrg = !string.IsNullOrEmpty(marketingRow["SalesOrg"].ToString()) ? marketingRow["SalesOrg"].ToString() : null,
                                      DistributionChannel = !string.IsNullOrEmpty(marketingRow["DistributionChannel"].ToString()) ? marketingRow["DistributionChannel"].ToString() : null,
                                      MarketingDescEn = !string.IsNullOrEmpty(marketingRow["MarketingDescEn"].ToString()) ? marketingRow["MarketingDescEn"].ToString() : null,
                                      MarketingDescFr = !string.IsNullOrEmpty(marketingRow["MarketingDescFr"].ToString()) ? marketingRow["MarketingDescFr"].ToString() : null,
                                      StyleKeywords = !string.IsNullOrEmpty(marketingRow["StyleKeywords"].ToString()) ? marketingRow["StyleKeywords"].ToString() : null,
                                      StyleSizeRun = !string.IsNullOrEmpty(marketingRow["StyleSizeRun"].ToString()) ? marketingRow["StyleSizeRun"].ToString() : null,
                                      NavCategory1 = !string.IsNullOrEmpty(marketingRow["NavCategory1"].ToString()) ? marketingRow["NavCategory1"].ToString() : null,
                                      NavCategory2 = !string.IsNullOrEmpty(marketingRow["NavCategory2"].ToString()) ? marketingRow["NavCategory2"].ToString() : null,
                                      NavCategory3 = !string.IsNullOrEmpty(marketingRow["NavCategory3"].ToString()) ? marketingRow["NavCategory3"].ToString() : null,
                                      NavCategory4 = !string.IsNullOrEmpty(marketingRow["NavCategory4"].ToString()) ? marketingRow["NavCategory4"].ToString() : null,
                                      NavCategoryFr1 = !string.IsNullOrEmpty(marketingRow["NavCategoryFr1"].ToString()) ? marketingRow["NavCategoryFr1"].ToString() : null,
                                      NavCategoryFr2 = !string.IsNullOrEmpty(marketingRow["NavCategoryFr2"].ToString()) ? marketingRow["NavCategoryFr2"].ToString() : null,
                                      NavCategoryFr3 = !string.IsNullOrEmpty(marketingRow["NavCategoryFr3"].ToString()) ? marketingRow["NavCategoryFr3"].ToString() : null,
                                      NavCategoryFr4 = !string.IsNullOrEmpty(marketingRow["NavCategoryFr4"].ToString()) ? marketingRow["NavCategoryFr4"].ToString() : null,
                                      Flag1 = !string.IsNullOrEmpty(marketingRow["Flag1"].ToString()) ? marketingRow["Flag1"].ToString() : null,
                                      Flag2 = !string.IsNullOrEmpty(marketingRow["Flag2"].ToString()) ? marketingRow["Flag2"].ToString() : null,
                                      Flag3 = !string.IsNullOrEmpty(marketingRow["Flag3"].ToString()) ? marketingRow["Flag3"].ToString() : null,
                                      Flag4 = !string.IsNullOrEmpty(marketingRow["Flag4"].ToString()) ? marketingRow["Flag4"].ToString() : null,
                                      Flag5 = !string.IsNullOrEmpty(marketingRow["Flag5"].ToString()) ? marketingRow["Flag5"].ToString() : null,
                                      Flag6 = !string.IsNullOrEmpty(marketingRow["Flag6"].ToString()) ? marketingRow["Flag6"].ToString() : null,
                                      Flag7 = !string.IsNullOrEmpty(marketingRow["Flag7"].ToString()) ? marketingRow["Flag7"].ToString() : null,
                                      Flag8 = !string.IsNullOrEmpty(marketingRow["Flag8"].ToString()) ? marketingRow["Flag8"].ToString() : null,
                                      Flag9 = !string.IsNullOrEmpty(marketingRow["Flag9"].ToString()) ? marketingRow["Flag9"].ToString() : null,
                                      Flag10 = !string.IsNullOrEmpty(marketingRow["Flag10"].ToString()) ? marketingRow["Flag10"].ToString() : null,
                                      Flag11 = !string.IsNullOrEmpty(marketingRow["Flag11"].ToString()) ? marketingRow["Flag11"].ToString() : null,
                                      Flag12 = !string.IsNullOrEmpty(marketingRow["Flag12"].ToString()) ? marketingRow["Flag12"].ToString() : null,
                                      CreatedOn = marketingRow["CreatedOn"] != DBNull.Value ? DateTime.Parse(marketingRow["CreatedOn"].ToString()) : DateTime.Now,
                                      UpdatedOn = DateTime.Now,
                                      IsCreatedOnNull = marketingRow["CreatedOn"] == DBNull.Value,
                                      Locale = locale
                                  }).ToList();
            
            int marketingInfoExceptions = 0;
            foreach (var row in exceptionsRows)
            {
                db.MarketingInfoCollection.Delete(string.Format("StyleNumber = '{0}' AND SalesOrg = '{1}' AND DistributionChannel = '{2}'",
                    row.StyleNumber, row.SalesOrg, row.DistributionChannel));
                db.MarketingInfo_ExceptionsCollection.Insert(row);

                marketingInfoExceptions++;
            }

            var flagsDataTable = db.FlagInfoCollection.GetAllAsDataTable();

            // Remove any orphaned flags and move to exceptions
            var flagInfoRows = (from DataRow flagsRow in flagsDataTable.Rows
                                where !marketingDataTable.Rows.Cast<DataRow>()
                                    .Any(marketingRow => flagsRow["FlagId"].ToString() == marketingRow["Flag1"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag2"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag3"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag4"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag5"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag6"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag7"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag8"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag9"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag10"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag11"].ToString() ||
                                        flagsRow["FlagId"].ToString() == marketingRow["Flag12"].ToString())
                                select new FlagInfo_ExceptionsRow
                                {
                                    FlagId = !string.IsNullOrEmpty(flagsRow["FlagId"].ToString()) ? flagsRow["FlagId"].ToString() : null,
                                    FlagName = flagsRow["FlagName"].ToString(),
                                    FlagNameFr = !string.IsNullOrEmpty(flagsRow["FlagNameFr"].ToString()) ? flagsRow["FlagNameFr"].ToString() : null,
                                    FlagDescription = !string.IsNullOrEmpty(flagsRow["FlagDescription"].ToString()) ? flagsRow["FlagDescription"].ToString() : null,
                                    FlagDescriptionFr = !string.IsNullOrEmpty(flagsRow["FlagDescriptionFr"].ToString()) ? flagsRow["FlagDescriptionFr"].ToString() : null,
                                    Category = flagsRow["Category"].ToString(),
                                    FileName = !string.IsNullOrEmpty(flagsRow["FileName"].ToString()) ? flagsRow["FileName"].ToString() : null,
                                    SalesOrg = flagsRow["SalesOrg"].ToString(),
                                    DistributionChannel = flagsRow["DistributionChannel"].ToString(),
                                    Sequence = flagsRow["Sequence"] != DBNull.Value ? (int)flagsRow["Sequence"] : 0,
                                    IsSequenceNull = flagsRow["Sequence"] == DBNull.Value,
                                    CreatedOn = flagsRow["CreatedOn"] != DBNull.Value ? DateTime.Parse(flagsRow["CreatedOn"].ToString()) : DateTime.Now,
                                    UpdatedOn = DateTime.Now,
                                    IsCreatedOnNull = flagsRow["CreatedOn"] == DBNull.Value,
                                    Locale = locale
                                }).ToList();

            int flagInfoExceptions = 0;
            foreach (var row in flagInfoRows)
            {
                db.FlagInfoCollection.Delete(string.Format("FlagId = '{0}'", row.FlagId));
                db.FlagInfo_ExceptionsCollection.Insert(row);

                flagInfoExceptions++;
            }

            var flagCategoriesDataTable = db.FlagCategoryCollection.GetAllAsDataTable();

            // Remove any orphaned flag categories and move to exceptions
            var flagCategoryRows = (from DataRow categoryRow in flagCategoriesDataTable.Rows
                                    where !flagsDataTable.Rows.Cast<DataRow>()
                                        .Any(flagsRow => categoryRow["Category"].ToString() == flagsRow["Category"].ToString() &&
                                            (categoryRow["SalesOrg"].ToString() == flagsRow["SalesOrg"].ToString() &&
                                            categoryRow["DistributionChannel"].ToString() == flagsRow["DistributionChannel"].ToString()))
                                    select new FlagCategory_ExceptionsRow
                                    {
                                        Category = categoryRow["Category"].ToString(),
                                        CategoryId = categoryRow["CategoryId"].ToString(),
                                        Sequence = categoryRow["Sequence"] != DBNull.Value ? (int)categoryRow["Sequence"] : 0,
                                        SalesOrg = categoryRow["SalesOrg"].ToString(),
                                        DistributionChannel = categoryRow["DistributionChannel"].ToString(),
                                        CreatedOn = categoryRow["CreatedOn"] != DBNull.Value ? DateTime.Parse(categoryRow["CreatedOn"].ToString()) : DateTime.Now,
                                        UpdatedOn = DateTime.Now,
                                        IsCreatedOnNull = categoryRow["CreatedOn"] == DBNull.Value,
                                        Locale = locale
                                    }).ToList();

            int categoryExceptions = 0;
            foreach (var row in flagCategoryRows)
            {
                db.FlagCategoryCollection.Delete(string.Format("CategoryId = '{0}'", row.CategoryId));
                db.FlagCategory_ExceptionsCollection.Insert(row);

                categoryExceptions++;
            }

            return string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", marketingInfoExceptions, iteTable.Rows.Count, marketingDataTable.Rows.Count,
                flagInfoExceptions, flagsDataTable.Rows.Count, categoryExceptions, flagCategoriesDataTable.Rows.Count);
        }

        /// <summary>
        /// Check if each brand has values in the ITE file. If not, send email to notify.
        /// </summary>
        private static bool ITEContainsAllBrands(DataTable iteTable, string locale)
        {
            bool hasBates = false;
            bool hasCat = false;
            bool hasChaco = false;
            bool hasCushe = false;
            bool hasHarley = false;
            bool hasHP = false;
            bool hasMerrell = false;
            bool hasMerrellApp = false;
            bool hasPatagonia = false;
            bool hasSebago = false;
            bool hasWolverine = false;
            bool hasWolverineApp = false;

            if (locale == "US")
            {
                foreach (DataRow row in iteTable.Rows)
                {
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "09")
                        hasBates = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "10")
                        hasCat = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "38")
                        hasChaco = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "18")
                        hasCushe = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "15")
                        hasHarley = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "02")
                        hasHP = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "30")
                        hasMerrell = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "AA")
                        hasMerrellApp = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "85")
                        hasPatagonia = true;
                    if (row["SalesOrg"].ToString() == "1700" && row["DistributionChannel"].ToString() == "80")
                        hasSebago = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "06")
                        hasWolverine = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "AD")
                        hasWolverineApp = true;
                    if (hasBates && hasCat && hasChaco && hasCushe && hasHarley && hasHP && hasMerrell &&
                        hasMerrellApp && hasPatagonia && hasSebago && hasWolverine && hasWolverineApp)
                        return true;
                }
            }
            
            if (locale == "CA")
            {
                foreach (DataRow row in iteTable.Rows)
                {
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "45")
                        hasBates = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "43")
                        hasCat = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "48")
                        hasChaco = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "47")
                        hasCushe = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "44")
                        hasHarley = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "41")
                        hasHP = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "31")
                        hasMerrell = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "AB")
                        hasMerrellApp = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "87")
                        hasPatagonia = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "46")
                        hasSebago = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "42")
                        hasWolverine = true;
                    if (row["SalesOrg"].ToString() == "4100" && row["DistributionChannel"].ToString() == "AE")
                        hasWolverineApp = true;
                    if (hasBates && hasCat && hasChaco && hasCushe && hasHarley && hasHP && hasMerrell &&
                        hasMerrellApp && hasPatagonia && hasSebago && hasWolverine && hasWolverineApp)
                        return true;
                }
            }

            if (locale == "WE" || locale == "FD")
            {
                foreach (DataRow row in iteTable.Rows)
                {
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "21")
                        hasBates = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "11")
                        hasCat = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "39")
                        hasChaco = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "19")
                        hasCushe = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "22")
                        hasHarley = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "03")
                        hasHP = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "34")
                        hasMerrell = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "AC")
                        hasMerrellApp = true;
                    if (row["SalesOrg"].ToString() == "3000" && row["DistributionChannel"].ToString() == "86")
                        hasPatagonia = true;
                    if (row["SalesOrg"].ToString() == "1700" && row["DistributionChannel"].ToString() == "81")
                        hasSebago = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "07")
                        hasWolverine = true;
                    if (row["SalesOrg"].ToString() == "1000" && row["DistributionChannel"].ToString() == "AF")
                        hasWolverineApp = true;
                    if (hasBates && hasCat && hasChaco && hasCushe && hasHarley && hasHP && hasMerrell &&
                        hasMerrellApp && hasPatagonia && hasSebago && hasWolverine && hasWolverineApp)
                        return true;
                }
            }

            var sb = new StringBuilder();

            if (!hasBates)
                sb.AppendLine("Bates");
            if (!hasCat)
                sb.AppendLine("Cat");
            if (!hasChaco)
                sb.AppendLine("Chaco");
            if (!hasCushe)
                sb.AppendLine("Cushe");
            if (!hasHarley)
                sb.AppendLine("Harley-Davidson");
            if (!hasHP)
                sb.AppendLine("Hush Puppies");
            if (!hasMerrell)
                sb.AppendLine("Merrell Footwear");
            if (!hasMerrellApp)
                sb.AppendLine("Merrell Apparel");
            if (!hasPatagonia)
                sb.AppendLine("Patagonia");
            if (!hasSebago)
                sb.AppendLine("Sebago");
            if (!hasWolverine)
                sb.AppendLine("Wolverine Footwear");
            if (!hasWolverineApp)
                sb.AppendLine("Wolverine Apparel");

            string missingBrands = sb.ToString();

            // This will kick off an email
            Log.ErrorFormat("Svc ({1}): Missing brand(s) from {1} ITE: {0}", missingBrands, locale);

            return false;
        }

        /// <summary>
        /// Checks a SAP file's line count against the previous line count to make sure it's legit.
        /// </summary>
        /// <param name="filePath">SAP file to check.</param>
        /// <returns>True if file contains a number of lines within the threshold.</returns>
        public static bool CheckSAPFileIsGood(string filePath, string locale)
        {
            var db = new B2BProductCatalog();
            var sapFileCheckRow = db.SAPFileCheckCollection.GetByFileType(filePath.Substring(filePath.IndexOf('.')+1), locale);

            int lineCount = 0;
            using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1252)))
            {
                while(streamReader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            Log.InfoFormat("Svc ({0}): Current Line Count: {1}, Previous Line Count: {2}, Threshold: {3}",
                locale, lineCount, sapFileCheckRow.PreviousLineCount, sapFileCheckRow.Threshold);
            sapFileCheckRow.CurrentLineCount = lineCount;

            if ((sapFileCheckRow.PreviousLineCount - sapFileCheckRow.CurrentLineCount) > sapFileCheckRow.Threshold)
            {
                // Send error message through email
                Log.ErrorFormat("Svc ({0}): Threshold of {1} exceeded in file {2}. Previous line count: {3}, current line count: {4}.",
                    locale, sapFileCheckRow.Threshold, filePath, sapFileCheckRow.PreviousLineCount, sapFileCheckRow.CurrentLineCount);

                db.SAPFileCheckCollection.Update(sapFileCheckRow);

                return false;
            }

            sapFileCheckRow.PreviousLineCount = lineCount;
            db.SAPFileCheckCollection.Update(sapFileCheckRow);

            return true;
        }

        public static bool MarketingInfoTableHasData()
        {
            var db = new B2BProductCatalog();

            int total = 5;
            if (db.MarketingInfoCollection.GetAsDataTable("", "", 0, 5, ref total).Rows.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Removes all existing marketing and flag info from the database.
        /// </summary>
        /// <param name="locale">Location to match</param>
        /// <param name="backupFirst">Insert existing data into backup tables before clearing.</param>
        public static void ClearData(string locale, bool backupFirst)
        {
            var db = new B2BProductCatalog();

            // Backup data in marketing/flags tables
            if (backupFirst)
            {
                foreach (var row in db.MarketingInfoCollection.GetAsArray("Locale='" + locale + "'", ""))
                {
                    var backup = new MarketingInfo_BackupRow
                    {
                        StyleNumber = row.StyleNumber,
                        SalesOrg = row.SalesOrg,
                        DistributionChannel = row.DistributionChannel,
                        StyleSizeRun = row.StyleSizeRun,
                        StyleKeywords = row.StyleKeywords,
                        MarketingDescEn = row.MarketingDescEn,
                        MarketingDescFr = row.MarketingDescFr,
                        NavCategory1 = row.NavCategory1,
                        NavCategory2 = row.NavCategory2,
                        NavCategory3 = row.NavCategory3,
                        NavCategory4 = row.NavCategory4,
                        NavCategoryFr1 = row.NavCategoryFr1,
                        NavCategoryFr2 = row.NavCategoryFr2,
                        NavCategoryFr3 = row.NavCategoryFr3,
                        NavCategoryFr4 = row.NavCategoryFr4,
                        Flag1 = row.Flag1,
                        Flag2 = row.Flag2,
                        Flag3 = row.Flag3,
                        Flag4 = row.Flag4,
                        Flag5 = row.Flag5,
                        Flag6 = row.Flag6,
                        Flag7 = row.Flag7,
                        Flag8 = row.Flag8,
                        Flag9 = row.Flag9,
                        Flag10 = row.Flag10,
                        Flag11 = row.Flag11,
                        Flag12 = row.Flag12,
                        CreatedOn = !row.IsCreatedOnNull ? row.CreatedOn : DateTime.MinValue,
                        UpdatedOn = !row.IsUpdatedOnNull ? row.UpdatedOn : DateTime.MinValue,
                        IsCreatedOnNull = row.IsCreatedOnNull,
                        IsUpdatedOnNull = row.IsUpdatedOnNull,
                        Locale = row.Locale
                    };

                    db.MarketingInfo_BackupCollection.Insert(backup);
                }

                foreach (var row in db.FlagInfoCollection.GetAsArray("Locale='" + locale + "'", ""))
                {
                    var backup = new FlagInfo_BackupRow
                    {
                        FlagId = row.FlagId,
                        FlagName = row.FlagName,
                        FlagNameFr = row.FlagNameFr,
                        FlagDescription = row.FlagDescription,
                        FlagDescriptionFr = row.FlagDescriptionFr,
                        SalesOrg = row.SalesOrg,
                        DistributionChannel = row.DistributionChannel,
                        Category = row.Category,
                        Sequence = row.Sequence,
                        FileName = row.FileName,
                        CreatedOn = !row.IsCreatedOnNull ? row.CreatedOn : DateTime.MinValue,
                        UpdatedOn = !row.IsUpdatedOnNull ? row.UpdatedOn : DateTime.MinValue,
                        IsCreatedOnNull = row.IsCreatedOnNull,
                        IsUpdatedOnNull = row.IsUpdatedOnNull,
                        Locale = row.Locale
                    };

                    db.FlagInfo_BackupCollection.Insert(backup);
                }

                foreach (var row in db.FlagCategoryCollection.GetAsArray("Locale='" + locale + "'", ""))
                {
                    var backup = new FlagCategory_BackupRow
                    {
                        CategoryId = row.CategoryId,
                        Category = row.Category,
                        SalesOrg = row.SalesOrg,
                        DistributionChannel = row.DistributionChannel,
                        Sequence = row.Sequence,
                        CreatedOn = !row.IsCreatedOnNull ? row.CreatedOn : DateTime.MinValue,
                        UpdatedOn = !row.IsUpdatedOnNull ? row.UpdatedOn : DateTime.MinValue,
                        IsCreatedOnNull = row.IsCreatedOnNull,
                        IsUpdatedOnNull = row.IsUpdatedOnNull,
                        Locale = row.Locale
                    };

                    db.FlagCategory_BackupCollection.Insert(backup);
                }
            }

            // Delete the records by locale
            db.MarketingInfoCollection.Delete("Locale='" + locale + "'");
            db.FlagInfoCollection.Delete("Locale='" + locale + "'");
            db.FlagCategoryCollection.Delete("Locale='" + locale + "'");
        }

        #region Product Images
        /// <summary>
        /// Creates images for all the styles currently in the MarketingInfo table.
        /// NOTE: Setup for service only at this point.
        /// </summary>
        /// <param name="pathToSave">Path where to save the images.</param>
        /// <param name="quality">Quality of image.</param>
        /// <param name="type">Image type: png or jpg.</param>
        public static string CreateImages(string pathToSave, string quality, string type, string salesOrg, string distChan, string locale)
        {
            var db = new B2BProductCatalog();
            DataTable marketingDataTable;

            if (salesOrg == "0000" && distChan == "00")
                // Generate images for all brands
                marketingDataTable = db.MarketingInfoCollection.GetAllByLocale(locale);
            else
                marketingDataTable = db.MarketingInfoCollection.GetAsDataTable(
                    string.Format("SalesOrg='{0}' AND DistributionChannel='{1}'", salesOrg, distChan), "");

            Log.InfoFormat("Begin image creation from {0} stock numbers.", marketingDataTable.Rows.Count);

            string rootUrl = ConfigurationManager.AppSettings["ImageRootUrl"];

            int imagesCount = 0;

            try
            {
                for (int i = 0; i < marketingDataTable.Rows.Count; i++)
                {
                    var stockNumber = marketingDataTable.Rows[i]["StyleNumber"].ToString();
                    var imageInfo = ExecuteOracle(stockNumber);

                    // Want to send a blank image if the image was incorrect and deleted from Image Bank
                    if (imageInfo.Rows.Count == 0) // If there is no image on Image Bank
                    {
                        var oldImage = db.ImageDataCollection.GetByStockNumber(stockNumber, locale);

                        if (oldImage != null) // And there is an image uploaded previously
                        {
                            // Copy NoImage image to Images folder with stock number name and delete old entry
                            Log.InfoFormat("Stock number \"{0}\" was removed from IB. Sending NoImage image and removing entry from db.", stockNumber);
                            File.Copy(pathToSave + "NoImage\\NoImage.png", String.Format("{0}{1}.png", pathToSave, stockNumber));
                            db.ImageDataCollection.Delete(oldImage);
                            continue;
                        }
                    }

                    if (imageInfo.Rows.Count > 0)
                    {
                        string path = string.Empty;
                        string fileName = string.Empty;
                        int mediaType = 0;

                        // Grab image marked as primary from web product or web apparel
                        foreach (DataRow row in from DataRow row in imageInfo.Rows
                                                where
                                                    row["mediatypeid"].ToString() == "1" ||
                                                    row["mediatypeid"].ToString() == "9"
                                                where
                                                    row["originalfilename"].ToString().Contains("-F-") ||
                                                    row["originalfilename"].ToString().Contains("-P.")
                                                select row)
                        {
                            path = row["imageloc"].ToString();
                            fileName = path;
                            mediaType = int.Parse(row["mediatypeid"].ToString());
                            break;
                        }

                        // Grab line drawing for apparel if we don't have an image yet
                        if (string.IsNullOrEmpty(path))
                        {
                            foreach (DataRow row in imageInfo.Rows.Cast<DataRow>()
                                .Where(row => row["mediatypeid"].ToString() == "11" &&
                                              (row["originalfilename"].ToString().Contains("-F-") ||
                                               row["originalfilename"].ToString().Contains("-P."))))
                            {
                                path = row["imageloc"].ToString();
                                fileName = path;
                                mediaType = int.Parse(row["mediatypeid"].ToString());
                                break;
                            }
                        }

                        // If we haven't found an image yet, just grab the first one
                        if (string.IsNullOrEmpty(path))
                        {
                            path = imageInfo.Rows[0]["imageloc"].ToString();
                            fileName = path;
                            mediaType = int.Parse(imageInfo.Rows[0]["mediatypeid"].ToString());
                        }

                        if (!string.IsNullOrEmpty(path))
                        {
                            // Before we save, check it against previous entry -- do we need to update an old image?
                            var oldImage = db.ImageDataCollection.GetByStockNumber(stockNumber, locale);
                            var imageBytes = new byte[] {};

                            // Only want to download image if it's new or updated
                            if (oldImage == null || oldImage.FileName != fileName)
                                imageBytes = GetBytesFromUrl(String.Format("{0}{1}?cell=1000,1000&qlt={2}&cvt={3}", rootUrl, path, quality, type), stockNumber);

                            if (imageBytes.Length > 0)
                            {
                                if (oldImage == null)
                                {
                                    if (!Directory.Exists(pathToSave))
                                        Directory.CreateDirectory(pathToSave);

                                    WriteBytesToFile(String.Format("{0}{1}.{2}", pathToSave, stockNumber, type), imageBytes);
                                    imagesCount++;

                                    db.ImageDataCollection.Insert(new ImageDataRow
                                                                      {
                                                                          StockNumber = stockNumber,
                                                                          CreatedOn = DateTime.Now,
                                                                          Url = rootUrl + path,
                                                                          FileName = fileName,
                                                                          MediaType = mediaType,
                                                                          Size = imageBytes.Length,
                                                                          Locale = locale
                                                                      });
                                }
                                else if (oldImage.FileName != fileName)
                                {
                                    if (!Directory.Exists(pathToSave))
                                        Directory.CreateDirectory(pathToSave);

                                    WriteBytesToFile(String.Format("{0}{1}.{2}", pathToSave, stockNumber, type), imageBytes);
                                    imagesCount++;

                                    oldImage.CreatedOn = DateTime.Now;
                                    oldImage.Url = rootUrl + path;
                                    oldImage.FileName = fileName;
                                    oldImage.MediaType = mediaType;
                                    oldImage.Size = imageBytes.Length;

                                    db.ImageDataCollection.Update(oldImage);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error creating images. Exception: {0}.", ex.Message);
            }

            Log.InfoFormat("{0} images created successfully.", imagesCount);

            return string.Format("{0}_{1}", imagesCount, marketingDataTable.Rows.Count);
        }

        /// <summary>
        /// Used for image creation.
        /// </summary>
        public static DataTable ExecuteOracle(string stockNumber)
        {
            var connection = new OracleConnection(ConfigurationManager.AppSettings["DataConnOracle"]);
            using (connection)
            {
                var imageInfo = new DataTable();

                try
                {
                    connection.Open();
                    //MediaTypeID (1- Web Product, 9 - Web Apparel, 11 - Line Drawing Apparel)
                    // NOTE: We've changed the ordering on the query 8/2/11
                    // This is due to updates to images on Image Bank being sorted by date so we will pick up updates
                    var selectCommand = new OracleCommand
                    {
                        Connection = connection,
                        CommandText = @"SELECT m.originalfilename, m.mediaid, s.stocknumber, m.brandid, m.mediatypeid,
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
								                AND m.mediatypeid IN (1,9,11)
						                ORDER BY m.createdby, s.stocknumber, m.isactive, m.createdat DESC"
                    };

                    var oracleDataAdapter = new OracleDataAdapter(selectCommand);
                    oracleDataAdapter.Fill(imageInfo);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("Error executing Oracle statement. Exception: {0}", ex.Message);
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }

                return imageInfo;
            }
        }
        #endregion

        #region Insert/Update db info
        public static string AddMarketingInfoToDb(DataTable marketingInfo, string locale)
        {
            int rowCountInserted = 0;
            int rowCountUpdated = 0;

            try
            {
                using (var db = new B2BProductCatalog())
                {
                    for (int i = 0; i < marketingInfo.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(marketingInfo.Rows[i]["Style"].ToString()) && marketingInfo.Rows[i]["Style"].ToString() != "0")
                        {
                            var row = new MarketingInfoRow
                            {
                                StyleNumber = marketingInfo.Rows[i]["Style"].ToString().TrimEnd(),
                                SalesOrg = SalesOrg,
                                DistributionChannel = DistChan,
                                Locale = locale
                            };

                            // Optional fields
                            if (marketingInfo.Rows[i]["Marketing Description"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Marketing Description"].ToString()))
                                row.MarketingDescEn = TruncateString(marketingInfo.Rows[i]["Marketing Description"].ToString(), 4000);
                            if (marketingInfo.Rows[i]["Marketing Description (FR)"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Marketing Description (FR)"].ToString()))
                                row.MarketingDescFr = TruncateString(marketingInfo.Rows[i]["Marketing Description (FR)"].ToString(), 4000);
                            if (marketingInfo.Rows[i]["Keywords"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Keywords"].ToString()))
                                row.StyleKeywords = TruncateString(marketingInfo.Rows[i]["Keywords"].ToString(), 1000);
                            if (marketingInfo.Rows[i]["Size Run"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Size Run"].ToString()))
                                row.StyleSizeRun = TruncateString(marketingInfo.Rows[i]["Size Run"].ToString(), 75);
                            if (marketingInfo.Rows[i]["Cat1"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat1"].ToString()))
                                row.NavCategory1 = TruncateString(marketingInfo.Rows[i]["Cat1"].ToString(), 100);
                            if (marketingInfo.Rows[i]["Cat2"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat2"].ToString()))
                                row.NavCategory2 = TruncateString(marketingInfo.Rows[i]["Cat2"].ToString(), 100);
                            if (marketingInfo.Rows[i]["Cat3"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat3"].ToString()))
                                row.NavCategory3 = TruncateString(marketingInfo.Rows[i]["Cat3"].ToString(), 100);
                            if (marketingInfo.Rows[i]["Cat4"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat4"].ToString()))
                                row.NavCategory4 = TruncateString(marketingInfo.Rows[i]["Cat4"].ToString(), 100);
                            if (marketingInfo.Columns.Contains("Cat1 (FR)") && marketingInfo.Rows[i]["Cat1 (FR)"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat1 (FR)"].ToString()))
                                row.NavCategoryFr1 = TruncateString(marketingInfo.Rows[i]["Cat1 (FR)"].ToString(), 100);
                            if (marketingInfo.Columns.Contains("Cat2 (FR)") && marketingInfo.Rows[i]["Cat2 (FR)"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat2 (FR)"].ToString()))
                                row.NavCategoryFr2 = TruncateString(marketingInfo.Rows[i]["Cat2 (FR)"].ToString(), 100);
                            if (marketingInfo.Columns.Contains("Cat3 (FR)") && marketingInfo.Rows[i]["Cat3 (FR)"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat3 (FR)"].ToString()))
                                row.NavCategoryFr3 = TruncateString(marketingInfo.Rows[i]["Cat3 (FR)"].ToString(), 100);
                            if (marketingInfo.Columns.Contains("Cat4 (FR)") && marketingInfo.Rows[i]["Cat4 (FR)"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Cat4 (FR)"].ToString()))
                                row.NavCategoryFr4 = TruncateString(marketingInfo.Rows[i]["Cat4 (FR)"].ToString(), 100);

                            // Flags written first, set MarketingInfo Flag fields to corresponding FlagId
                            if (marketingInfo.Rows[i]["Flag 1"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 1"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 1"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag1 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 2"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 2"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 2"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag2 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 3"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 3"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 3"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag3 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 4"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 4"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 4"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag4 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 5"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 5"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 5"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag5 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 6"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 6"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 6"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag6 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 7"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 7"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 7"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag7 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 8"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 8"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 8"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag8 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 9"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 9"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 9"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag9 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 10"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 10"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 10"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag10 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 11"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 11"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 11"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag11 = flagInfoRow.FlagId;
                            }
                            if (marketingInfo.Rows[i]["Flag 12"] != null
                                && !string.IsNullOrEmpty(marketingInfo.Rows[i]["Flag 12"].ToString()))
                            {
                                var flagInfoRow = db.FlagInfoCollection.GetByFlagName(marketingInfo.Rows[i]["Flag 12"].ToString(), SalesOrg, DistChan, locale);
                                if (flagInfoRow != null)
                                    row.Flag12 = flagInfoRow.FlagId;
                            }

                            var marketingInfoRow = db.MarketingInfoCollection.GetByStyleNumberSOandDC(row.StyleNumber, row.SalesOrg, row.DistributionChannel, locale);

                            if (marketingInfoRow == null)
                            {
                                row.CreatedOn = DateTime.Now;
                                db.MarketingInfoCollection.Insert(row);
                                rowCountInserted++;
                            }
                            else
                            {
                                row.PkId = marketingInfoRow.PkId;
                                row.UpdatedOn = DateTime.Now;
                                db.MarketingInfoCollection.Update(row);
                                rowCountUpdated++;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error inserting values into MarketingInfo table. Exception: {0}", ex.Message);
            }

            return string.Format("{0}_{1}", rowCountInserted, rowCountUpdated);
        }

        public static string AddFlagInfoToDb(DataTable flagInfo, DataTable categoryInfo, string locale)
        {
            int flagInfoInserted = 0;
            int flagInfoUpdated = 0;
            int categoryInserted = 0;
            int categoryUpdated = 0;

            try
            {
                using (var db = new B2BProductCatalog())
                {
                    // Flag Info
                    for (int i = 0; i < flagInfo.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(flagInfo.Rows[i]["Flag Name"].ToString()))
                        {
                            var row = new FlagInfoRow
                            {
                                FlagId = flagInfo.Rows[i]["Flag ID"].ToString().Replace('_', '-'),
                                FlagName = TruncateString(flagInfo.Rows[i]["Flag Name"].ToString(), 50),
                                Category = !string.IsNullOrEmpty(flagInfo.Rows[i]["Flag Category"].ToString()) ? TruncateString(flagInfo.Rows[i]["Flag Category"].ToString(), 50) : "N/A",
                                SalesOrg = SalesOrg,
                                DistributionChannel = DistChan,
                                Locale = locale
                            };

                            // Optional fields
                            if (flagInfo.Rows[i]["Flag Description"] != null
                                && !string.IsNullOrEmpty(flagInfo.Rows[i]["Flag Description"].ToString()))
                                row.FlagDescription = TruncateString(flagInfo.Rows[i]["Flag Description"].ToString(), 4000);
                            if (flagInfo.Rows[i]["Flag File Name"] != null
                                && !string.IsNullOrEmpty(flagInfo.Rows[i]["Flag File Name"].ToString()))
                                row.FileName = flagInfo.Rows[i]["Flag File Name"].ToString();
                            if (flagInfo.Columns.Contains("Flag Name (FR)") && flagInfo.Rows[i]["Flag Name (FR)"] != null
                                && !string.IsNullOrEmpty(flagInfo.Rows[i]["Flag Name (FR)"].ToString()))
                                row.FlagNameFr = TruncateString(flagInfo.Rows[i]["Flag Name (FR)"].ToString(), 75);
                            if (flagInfo.Columns.Contains("Flag Description (FR)") && flagInfo.Rows[i]["Flag Description (FR)"] != null
                                && !string.IsNullOrEmpty(flagInfo.Rows[i]["Flag Description (FR)"].ToString()))
                                row.FlagDescriptionFr = TruncateString(flagInfo.Rows[i]["Flag Description (FR)"].ToString(), 4000);
                            if (flagInfo.Rows[i]["Sequence"] != null
                                && !string.IsNullOrEmpty(flagInfo.Rows[i]["Sequence"].ToString()))
                                row.Sequence = int.Parse(flagInfo.Rows[i]["Sequence"].ToString());
                            else
                                row.Sequence = 9999; //per iCongo, default to 9999 if not supplied

                            var flagInfoRow = db.FlagInfoCollection.GetByFlagID(row.FlagId);

                            if (flagInfoRow == null)
                            {
                                row.CreatedOn = DateTime.Now;
                                db.FlagInfoCollection.Insert(row);
                                flagInfoInserted++;
                            }
                            else
                            {
                                row.PkId = flagInfoRow.PkId;
                                row.UpdatedOn = DateTime.Now;
                                db.FlagInfoCollection.Update(row);
                                flagInfoUpdated++;
                            }
                        }
                    }

                    // Flag Categories
                    for (int j = 0; j < categoryInfo.Rows.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(categoryInfo.Rows[j]["Flag Category"].ToString()))
                        {
                            var row = new FlagCategoryRow
                                      {
                                          Category = TruncateString(categoryInfo.Rows[j]["Flag Category"].ToString(), 50),
                                          CategoryId = categoryInfo.Rows[j]["Flag Category ID"].ToString().Replace('_', '-'),
                                          SalesOrg = SalesOrg,
                                          DistributionChannel = DistChan,
                                          Locale = locale
                                      };

                            if (categoryInfo.Columns.Contains("Flag Category (FR)") && categoryInfo.Rows[j]["Flag Category (FR)"] != null
                              && !string.IsNullOrEmpty(categoryInfo.Rows[j]["Flag Category (FR)"].ToString()))
                                row.CategoryFr = TruncateString(categoryInfo.Rows[j]["Flag Category (FR)"].ToString(), 50);
                            if (categoryInfo.Rows[j]["Sequence"] != null && !string.IsNullOrEmpty(categoryInfo.Rows[j]["Sequence"].ToString()))
                                row.Sequence = int.Parse(categoryInfo.Rows[j]["Sequence"].ToString());
                            else
                                row.Sequence = 9999; //per iCongo, default to 9999 if not supplied

                            var flagCategoryRow = db.FlagCategoryCollection.GetByFlagCategory(row.Category, SalesOrg, DistChan, locale);

                            if (flagCategoryRow == null)
                            {
                                row.CreatedOn = DateTime.Now;
                                db.FlagCategoryCollection.Insert(row);
                                categoryInserted++;
                            }
                            else
                            {
                                row.PkId = flagCategoryRow.PkId;
                                row.UpdatedOn = DateTime.Now;
                                db.FlagCategoryCollection.Update(row);
                                categoryUpdated++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error inserting values into Flags table. Exception: {0}", ex.Message);
            }

            return string.Format("{0}_{1}_{2}_{3}", flagInfoInserted, flagInfoUpdated, categoryInserted, categoryUpdated);
        }

        public static string ParseXmlForB2CData(string fileName)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(fileName);

                //DEV NOTE: 
                //2 different way to get at a nested collection 
                //Stock Numbers - array of objects
                //ProductDescAlt - typed list (3084 - French Canada, 1033 - English US)

                // accounts for DefaultProudctDesc element missing
                List<B2CMaterial> B2CMaterials =
                  (from product in xmlDoc.Descendants("Product")
                   let DefaultProductDesc = product.Element("DefaultProductDesc")
                   where DefaultProductDesc != null
                   select new B2CMaterial
                   {
                       ProductName = product.Attribute("ProductName").Value,
                       BrandName = product.Attribute("BrandName").Value,
                       DefaultProductDesc = product.Element("DefaultProductDesc").GetElementValue(),
                       StockNumbers = product.Elements("Style").Attributes("StockNumber").ToArray(),
                       ProductDescAlt = (from proddesc in product.Elements("ProductDesc")
                                         where proddesc.Attribute("LocaleID").Value == "3084"
                                         select new B2CProductDescAlt
                                         {
                                             ProductDsc = proddesc.Value,
                                             LocaleID = proddesc.Attribute("LocaleID").Value
                                         }).ToList(),
                       ProductOverview = (from prodover in product.Elements("ProductOverview")
                                          where prodover.Attribute("LocaleID").Value == "1033"
                                          select new B2CProductOverview
                                          {
                                              ProductOverview = prodover.Value,
                                              LocaleID = prodover.Attribute("LocaleID").Value
                                          }).ToList()
                   }).ToList();


                int countOfB2CPatterns = B2CMaterials.Count;
                int countOfB2CStyles = 0;
                int countOfB2CStyleInserted = 0;
                int countOfB2CStyleDups = 0;
                int countOfB2CStyleLongerThan18Chars = 0;
                int countOfB2CStyleUpdatedWithFrench = 0;
                string styleDescriptionFrench;

                if (countOfB2CPatterns != 0)
                {
                    //found some materials, loop through them
                    string styleNumber;

                    using (var connection = new SqlConnection())
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["B2BProductCatalogDB"].ToString();
                        connection.Open();

                        SqlCommand cmd;

                        foreach (B2CMaterial style in B2CMaterials)
                        {
                            //dataGridViewMessages.Rows.Add(style.ProductName);

                            //get french description if exists
                            styleDescriptionFrench = "";
                            if (style.ProductDescAlt.Count() != 0)
                                styleDescriptionFrench = style.ProductDescAlt.ElementAt(0).ProductDsc;

                            //get product overview (english - 1033) if exists [it is in addition to the technical bullets for some brands]
                            string styleProductOverviewEn = "";
                            if (style.ProductOverview.Count() != 0)
                                styleProductOverviewEn = style.ProductOverview.ElementAt(0).ProductOverview;

                            if (style.StockNumbers.Count() != 0)
                            {
                                //each material should have at least one style
                                foreach (object stocknumber in style.StockNumbers)
                                {
                                    styleNumber = ((XAttribute)stocknumber).Value;
                                    //dataGridViewMessages.Rows.Add(styleNumber);

                                    countOfB2CStyles++;

                                    //check if the Style already exists
                                    cmd = new SqlCommand
                                          {
                                              Connection = connection,
                                              CommandType = CommandType.Text,
                                              CommandText = @"SELECT COUNT(*) AS CountOfStyle
                                                              FROM B2CProductData
                                                              WHERE StyleNumber = @StyleNumber"
                                          };

                                    cmd.Parameters.Add(new SqlParameter("StyleNumber", styleNumber));

                                    bool styleAlreadyExists = (int.Parse(cmd.ExecuteScalar().ToString()) != 0);

                                    if (styleAlreadyExists)
                                    {
                                        //existing style - update (???)
                                        countOfB2CStyleDups++;

                                        //the only time a style should be updated is when
                                        //french description did not exist
                                        if (styleDescriptionFrench.Length != 0)
                                        {
                                            countOfB2CStyleUpdatedWithFrench++;

                                            //update style with french
                                            cmd = new SqlCommand
                                                  {
                                                      Connection = connection,
                                                      CommandType = CommandType.Text,
                                                      CommandText = @"UPDATE B2CProductData
                                                                      SET ProductDescFr = @ProductDescFr
                                                                      WHERE StyleNumber = @StyleNumber"
                                                  };

                                            cmd.Parameters.Add(new SqlParameter("StyleNumber", styleNumber));
                                            cmd.Parameters.Add(new SqlParameter("ProductDescFr", styleDescriptionFrench));
                                        }
                                    }
                                    else
                                    {
                                        //new style - add

                                        //found out that some Material Numbers from B2C 
                                        //are greater than 18 characters in length - skip these
                                        if (styleNumber.Length > 18)
                                        {
                                            countOfB2CStyleLongerThan18Chars++;
                                        }
                                        else
                                        {
                                            //add new style
                                            cmd = new SqlCommand
                                                  {
                                                      Connection = connection,
                                                      CommandType = CommandType.Text,
                                                      CommandText =
                                                          @"INSERT INTO B2CProductData
                                                            (StyleNumber,ProductName, BrandName, ProductDescEn, ProductDescFr)
                                                            VALUES (@StyleNumber, @ProductName,@BrandName,@ProductDescEn,@ProductDescFr)"
                                                  };

                                            cmd.Parameters.Add(new SqlParameter("StyleNumber", styleNumber));
                                            cmd.Parameters.Add(new SqlParameter("ProductName", style.ProductName));
                                            cmd.Parameters.Add(new SqlParameter("BrandName", style.BrandName));

                                            if (!String.IsNullOrEmpty(styleProductOverviewEn))
                                            {
                                                //if there is a product overview add it on top of the Product Description En
                                                cmd.Parameters.Add(new SqlParameter("ProductDescEn",
                                                    string.Format("{0}<br />{1}", styleProductOverviewEn, style.DefaultProductDesc)));
                                            }
                                            else
                                                cmd.Parameters.Add(new SqlParameter("ProductDescEn", style.DefaultProductDesc));

                                            cmd.Parameters.Add(styleDescriptionFrench.Length != 0
                                                                   ? new SqlParameter("ProductDescFr", styleDescriptionFrench)
                                                                   : new SqlParameter("ProductDescFr", DBNull.Value));

                                            countOfB2CStyleInserted++;
                                        }

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    return string.Format("{0}_{1}_{2}_{3}_{4}_{5}", countOfB2CPatterns, countOfB2CStyles, countOfB2CStyleInserted, countOfB2CStyleDups, countOfB2CStyleUpdatedWithFrench, countOfB2CStyleLongerThan18Chars);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error in B2C data import: {0}", ex.Message);
            }

            return string.Empty;
        }
        #endregion

        #region File Creation
        public static void CreateMarketingInfoFile(string filePath, string fileType, bool useB2CData, string locale)
        {
            var db = new B2BProductCatalog();
            var marketingDataTable = db.MarketingInfoCollection.GetAllByLocale(locale);

            if (useB2CData)
            {
                for (int i = 0; i < marketingDataTable.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(marketingDataTable.Rows[i]["MarketingDescEn"].ToString()))
                    {
                        var row = db.B2CProductDataCollection.GetByStyleNumber(marketingDataTable.Rows[i]["StyleNumber"].ToString());

                        if (row != null)
                            if (!string.IsNullOrEmpty(row.ProductDescEn))
                            {
                                marketingDataTable.Rows[i].BeginEdit();
                                marketingDataTable.Rows[i]["MarketingDescEn"] = row.ProductDescEn;
                                marketingDataTable.Rows[i].EndEdit();
                            }
                    }
                    if (string.IsNullOrEmpty(marketingDataTable.Rows[i]["MarketingDescFr"].ToString()))
                    {
                        var row = db.B2CProductDataCollection.GetByStyleNumber(marketingDataTable.Rows[i]["StyleNumber"].ToString());

                        if (row != null)
                            if (!string.IsNullOrEmpty(row.ProductDescFr))
                            {
                                marketingDataTable.Rows[i].BeginEdit();
                                marketingDataTable.Rows[i]["MarketingDescFr"] = row.ProductDescFr;
                                marketingDataTable.Rows[i].EndEdit();
                            }
                    }
                }
            }

            try
            {
                using (var streamWriter = new StreamWriter(filePath, false, Encoding.GetEncoding(1252)))
                {
                    int iColCount = marketingDataTable.Columns.Count;

                    if (fileType.ToLower() == "mcsv")
                    {
                        //only write-out headers if not using the MKT format (required by iCongo)
                        for (int i = 0; i < iColCount; i++)
                        {
                            streamWriter.Write(marketingDataTable.Columns[i]);

                            if (i < iColCount - 1)
                            {
                                streamWriter.Write(",");
                            }
                        }

                        streamWriter.Write(streamWriter.NewLine);
                    }

                    foreach (DataRow dataRow in marketingDataTable.Rows)
                    {
                        if (fileType.ToLower() == "mmkt")
                        {
                            //when using the MKT format (required by iCongo) only write-out specific columns
                            //StyleNumber, MarketingDescEn, MarketingDescFr, Keywords, SizeRun
                            
                            streamWriter.Write(GetLocationAbbreviation(locale) + "|");

                            //StyleNumber
                            streamWriter.Write(!Convert.IsDBNull(dataRow[1])
                                                   ? string.Format("{0}|", StripBadCharacters(dataRow[1].ToString()))
                                                   : "|");
                            //MarketingDescEn, pipe in N/A if empty
                            streamWriter.Write(!Convert.IsDBNull(dataRow[4])
                                                   ? string.Format("{0}|", HTMLEncodeSpecialChars(StripBadCharacters(dataRow[4].ToString())))
                                                   : "Description not available|");

                            //MarketingDescFr
                            if (!Convert.IsDBNull(dataRow[5]))
                                //French Marketing Description Exists
                                streamWriter.Write(string.Format("{0}|", HTMLEncodeSpecialChars(StripBadCharacters(dataRow[5].ToString()))));
                            else
                            {
                                //French Marketing Description is missing
                                if (!Convert.IsDBNull(dataRow[4]))
                                {
                                    //if English is available, use English for French
                                    streamWriter.Write(string.Format("{0}|", HTMLEncodeSpecialChars(StripBadCharacters(dataRow[4].ToString()))));
                                }
                                else
                                    //otherwise pipe in N/A if empty
                                    streamWriter.Write("Description not available|");
                            }


                            //Keywords
                            streamWriter.Write(!Convert.IsDBNull(dataRow[6])
                                                   ? string.Format("{0}|", StripBadCharacters(dataRow[6].ToString()))
                                                   : "|");
                            //SizeRun
                            if (!Convert.IsDBNull(dataRow[7]))
                            {
                                streamWriter.Write(string.Format("{0}", StripBadCharacters(dataRow[7].ToString())));
                            }

                        }
                        else
                        {
                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(dataRow[i]))
                                {
                                    string formattedData = dataRow[i].ToString()
                                        .Replace("\r\n", "<br />").Replace("\n", "<br />").Replace(",", "&#44;");
                                    streamWriter.Write(formattedData);
                                }

                                if (i < iColCount - 1)
                                {
                                    streamWriter.Write(",");
                                }
                            }
                        }

                        streamWriter.Write(streamWriter.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error creating marketing info file. Exception: {0}", ex.Message);
            }
        }

        public static void CreateFlgFile(string filePath, string locale)
        {
            var db = new B2BProductCatalog();
            var flagInfoTable = db.FlagInfoCollection.GetFlagInfoWithCategoryId();

            try
            {
                using (var streamWriter = new StreamWriter(filePath, false, Encoding.GetEncoding(1252)))
                {
                    foreach (DataRow dataRow in flagInfoTable.Rows)
                    {
                        streamWriter.Write(GetLocationAbbreviation(locale) + "|");

                        // FlagId
                        streamWriter.Write(!Convert.IsDBNull(dataRow[0])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[0].ToString()))
                                               : "|");

                        // FlagName (use N/A if missing)
                        string flagNameEn = (!Convert.IsDBNull(dataRow[1]) ? StripBadCharacters(dataRow[1].ToString()) : "N/A");
                        streamWriter.Write(string.Format("{0}|", flagNameEn));

                        // FlagNameFr (iCongo requires English if French is missing)
                        string flagNameFr = (!Convert.IsDBNull(dataRow[2]) ? StripBadCharacters(dataRow[2].ToString()) : "N/A");
                        streamWriter.Write(flagNameFr!="N/A"
                                               ? string.Format("{0}|", flagNameFr)
                                               : string.Format("{0}|", flagNameEn));

                        // FlagDescription (use N/A if missing)

                        streamWriter.Write(!Convert.IsDBNull(dataRow[3])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[3].ToString()))
                                               : "N/A|");

                        // FlagDescriptionFr
                        if (!Convert.IsDBNull(dataRow[4]))
                            //French Flag Description Exists
                            streamWriter.Write(string.Format("{0}|", StripBadCharacters(dataRow[4].ToString())));
                        else
                        {
                            //French Flag Description is missing
                            streamWriter.Write(!Convert.IsDBNull(dataRow[3])
                                                   ? string.Format("{0}|", StripBadCharacters(dataRow[3].ToString()))
                                                   : "N/A|");
                        }

                        // SalesOrg
                        streamWriter.Write(!Convert.IsDBNull(dataRow[5])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[5].ToString()))
                                               : "|");

                        // DistributionChannel
                        streamWriter.Write(!Convert.IsDBNull(dataRow[6])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[6].ToString()))
                                               : "|");

                        // CategoryId
                        streamWriter.Write(!Convert.IsDBNull(dataRow[7])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[7].ToString()))
                                               : "|");

                        // Sequence
                        streamWriter.Write(!Convert.IsDBNull(dataRow[8])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[8].ToString()))
                                               : "|");

                        // Send 'C' for 'Create'
                        streamWriter.Write("C" + streamWriter.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error creating FLG file. Exception: {0}", ex.Message);
            }
        }

        public static void CreateFlcFile(string filePath, string locale)
        {
            var db = new B2BProductCatalog();
            var flagInfoTable = db.FlagCategoryCollection.GetAllAsDataTable();

            try
            {
                using (var streamWriter = new StreamWriter(filePath, false, Encoding.GetEncoding(1252)))
                {
                    foreach (DataRow dataRow in flagInfoTable.Rows)
                    {
                        streamWriter.Write(GetLocationAbbreviation(locale) + "|");

                        // SalesOrg
                        streamWriter.Write(!Convert.IsDBNull(dataRow[5])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[5].ToString()))
                                               : "|");

                        // DistributionChannel
                        streamWriter.Write(!Convert.IsDBNull(dataRow[6])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[6].ToString()))
                                               : "|");

                        // CategoryId
                        streamWriter.Write(!Convert.IsDBNull(dataRow[3])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[3].ToString()))
                                               : "|");

                        // FlagCategoryName, pipe in N/A if empty
                        streamWriter.Write(!Convert.IsDBNull(dataRow[1])
                                               ? string.Format("{0}|", HTMLEncodeSpecialChars(StripBadCharacters(dataRow[1].ToString())))
                                               : "N/A|");

                        // FlagCategoryNameFr
                        if (!Convert.IsDBNull(dataRow[2]))
                            //French Flag Category Name Exists
                            streamWriter.Write(string.Format("{0}|", HTMLEncodeSpecialChars(StripBadCharacters(dataRow[2].ToString()))));
                        else
                        {
                            //French Flag Category Name is missing
                            streamWriter.Write(!Convert.IsDBNull(dataRow[1])
                                                   ? string.Format("{0}|", StripBadCharacters(dataRow[1].ToString()))
                                                   : "N/A|");
                        }

                        // Sequence, if blank send 9999
                        streamWriter.Write(!Convert.IsDBNull(dataRow[4])
                                               ? string.Format("{0}|", StripBadCharacters(dataRow[4].ToString()))
                                               : "9999|");

                        // Send 'C' for 'Create'
                        streamWriter.Write("C" + streamWriter.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error creating FLC file. Exception: {0}", ex.Message);
            }
        }

        public static void CreateFsaFile(string filePath, string locale)
        {
            var db = new B2BProductCatalog();
            var marketingInfoTable = db.MarketingInfoCollection.GetAllByLocale(locale);

            try
            {
                using (var streamWriter = new StreamWriter(filePath, false, Encoding.GetEncoding(1252)))
                {
                    foreach (DataRow dataRow in marketingInfoTable.Rows)
                    {
                        // ItemId = StyleNumber
                        var styleNumber = Convert.IsDBNull(dataRow[1]) ? "" : StripBadCharacters(dataRow[1].ToString());

                        if (styleNumber.Length != 0)
                        {
                            // FlagIds related to that StyleNumber
                            // Flags 1-12
                            if (!Convert.IsDBNull(dataRow[16]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[16].ToString()));
                            if (!Convert.IsDBNull(dataRow[17])) // Flag 2
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[17].ToString()));
                            if (!Convert.IsDBNull(dataRow[18]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[18].ToString()));
                            if (!Convert.IsDBNull(dataRow[19]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[19].ToString()));
                            if (!Convert.IsDBNull(dataRow[20]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[20].ToString()));
                            if (!Convert.IsDBNull(dataRow[21]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[21].ToString()));
                            if (!Convert.IsDBNull(dataRow[22]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[22].ToString()));
                            if (!Convert.IsDBNull(dataRow[23]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[23].ToString()));
                            if (!Convert.IsDBNull(dataRow[24]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[24].ToString()));
                            if (!Convert.IsDBNull(dataRow[25]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[25].ToString()));
                            if (!Convert.IsDBNull(dataRow[26]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[26].ToString()));
                            if (!Convert.IsDBNull(dataRow[27]))
                                streamWriter.WriteLine(HelpAssembleFsaEntry(GetLocationAbbreviation(locale), styleNumber, dataRow[27].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error creating FSA file. Exception: {0}", ex.Message);
            }
        }
        #endregion

        #region Helpers
        private static byte[] GetBytesFromUrl(string url, string stockNumber)
        {
            var bytes = new byte[] {};

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                using (var response = request.GetResponse())
                {
                    var stream = response.GetResponseStream();
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        bytes = binaryReader.ReadBytes(2000000);
                        stream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error fetching image for {2}. Url: '{0}'. Exception: {1}", url, ex.Message, stockNumber);
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
            catch (Exception ex)
            {
                Log.ErrorFormat("Error writing image. Exception: {0}", ex.Message);
            }
            finally
            {
                fileStream.Close();
                binaryWriter.Close();
            }
        }

        private static string StripBadCharacters(string input)
        {
            return input.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("|", "&#124;");
        }

        private static string GetLocationAbbreviation(string locale)
        {
            string location;

            switch (locale)
            {
                case "CA":
                    location = "CAN";
                    break;
                case "WE":
                    location = "WHS";
                    break;
                case "FD":
                    location = "FAC";
                    break;
                default:
                    location = "US";
                    break;
            }

            return location;
        }

        /// <summary>
        /// Helper method to encode special characters in the Marketing Description
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HTMLEncodeSpecialChars(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c > 127) // special chars
                    sb.Append(String.Format("&#{0};", (int)c));
                else
                    sb.Append(c);
            }
            return sb.ToString();
        } 

        /// <summary>
        /// Helper method to aid with building a single line of the FSA file
        /// </summary>
        private static string HelpAssembleFsaEntry(string businessUnitId, string itemId, string flagId)
        {
            // Entry Spec:
            // BusinessUnitID, ItemID, FlagID, StartDate (MM/DD/YYYY), EndDate, Activity ('C' for 'Create', 'D' for Delete)
            if (businessUnitId == "CA")
                businessUnitId = "CAN";

            // StartDate = Today - 1 for now
            var yesterday = string.Format("{0:dd/MM/yyyy}", DateTime.Today.AddDays(-1));

            // EndDate = Today + 365 for now
            var nextYear = string.Format("{0:dd/MM/yyyy}", DateTime.Today.AddYears(1));

            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}", businessUnitId, itemId,
                StripBadCharacters(flagId), yesterday, nextYear, "C");
        }

        /// <summary>
        /// Used to prevent Excel entries from being too long for the database fields.
        /// </summary>
        /// <param name="input">Excel entry to check</param>
        /// <param name="fieldLength">Length of the database field</param>
        /// <returns>Truncated string</returns>
        private static string TruncateString(string input, int fieldLength)
        {
            return input.Length > fieldLength ? input.Substring(0, fieldLength) : input;
        }

        #endregion
    }

    public class B2CMaterial
    {
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string DefaultProductDesc { get; set; }
        public object[] StockNumbers { get; set; }
        public List<B2CProductDescAlt> ProductDescAlt { get; set; }
        public List<B2CProductOverview> ProductOverview { get; set; }
    }

    public class B2CProductDescAlt
    {
        public string ProductDsc { get; set; }
        public string LocaleID { get; set; }
    }

    public class B2CProductOverview
    {
        public string ProductOverview { get; set; }
        public string LocaleID { get; set; }
    }

    public class B2CMaterialSource
    {
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string DefaultProductDesc { get; set; }
        public string StockNumber { get; set; }
    }

    public static class XElementHelper
    {
        //helper methods
        public static string GetAttributeValue(this XElement element, string attributeName)
        {
            XAttribute attribute = element.Attribute(attributeName);
            return attribute != null ? attribute.Value : string.Empty;
        }

        public static string GetElementValue(this XElement element)
        {
            return element != null ? element.Value : string.Empty;
        }

        public static string GetElementValue(this XElement element, string elementName)
        {
            XElement child = element.Element(elementName);
            return child != null ? child.Value : string.Empty;
        }
    }
}
