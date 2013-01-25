// <fileinfo name="FlagInfoCollection.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			You can update this source code manually. If the file
//			already exists it will not be rewritten by the generator.
//		</remarks>
//		<generator rewritefile="False" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;
using System.Data;

namespace MarketingGenerator.Core.DbObjects
{
	/// <summary>
	/// Represents the <c>FlagInfo</c> table.
	/// </summary>
	public class FlagInfoCollection : FlagInfoCollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FlagInfoCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal FlagInfoCollection(B2BProductCatalog db)
				: base(db)
		{
			// EMPTY
		}

        public FlagInfoRow GetByFlagName(string flagName, string salesOrg, string distChan, string locale)
        {
            string whereSql = "[FlagName]=" + Database.CreateSqlParameterName("FlagName") +
                " AND [SalesOrg]=" + Database.CreateSqlParameterName("SalesOrg") +
                " AND [DistributionChannel]=" + Database.CreateSqlParameterName("DistributionChannel") +
                " AND [Locale]=" + Database.CreateSqlParameterName("Locale");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "FlagName", flagName);
            AddParameter(cmd, "SalesOrg", salesOrg);
            AddParameter(cmd, "DistributionChannel", distChan);
            AddParameter(cmd, "Locale", locale);
            FlagInfoRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }

        public FlagInfoRow GetByFlagID(string flagId)
        {
            string whereSql = "[FlagId]=" + Database.CreateSqlParameterName("FlagId");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "FlagId", flagId);
            FlagInfoRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }

        public DataTable GetFlagInfoWithCategoryId()
        {
            using (IDataReader reader = Database.ExecuteReader(SelectCategories()))
            {
                return MapToDataTable(reader);
            }
        }

        private IDbCommand SelectCategories()
        {
            const string sql = @"SELECT FI.FlagId, FI.FlagName, FI.FlagNameFr, FI.FlagDescription, FI.FlagDescriptionFr, FI.SalesOrg,
	                                 FI.DistributionChannel, FC.CategoryId, FI.Sequence
                                 FROM FlagCategory FC, FlagInfo FI
                                 WHERE FC.Category = FI.Category
                                 AND FC.SalesOrg = FI.SalesOrg
                                 AND FC.DistributionChannel = FI.DistributionChannel
                                 GROUP BY FI.FlagId, FI.FlagName, FI.FlagNameFr, FI.FlagDescription, FI.FlagDescriptionFr, FI.SalesOrg,
	                                 FI.DistributionChannel, FC.CategoryId, FI.Sequence";

            return Database.CreateCommand(sql);
        }

        private DataTable MapToDataTable(IDataReader reader)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "FlagInfo";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("FlagId", typeof(string));
            dataColumn.MaxLength = 15;
            dataColumn = dataTable.Columns.Add("FlagName", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("FlagNameFr", typeof(string));
            dataColumn.MaxLength = 75;
            dataColumn = dataTable.Columns.Add("FlagDescription", typeof(string));
            dataColumn.MaxLength = 4000;
            dataColumn = dataTable.Columns.Add("FlagDescriptionFr", typeof(string));
            dataColumn.MaxLength = 4000;
            dataColumn = dataTable.Columns.Add("SalesOrg", typeof(string));
            dataColumn.MaxLength = 4;
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("DistributionChannel", typeof(string));
            dataColumn.MaxLength = 2;
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("CategoryId", typeof(string));
            dataColumn.MaxLength = 15;
            dataTable.Columns.Add("Sequence", typeof(int));

            dataTable.BeginLoadData();

            object[] values = new object[reader.FieldCount];

            while (reader.Read())
            {
                reader.GetValues(values);
                dataTable.LoadDataRow(values, true);
            }
            dataTable.EndLoadData();

            return dataTable;
        }
	} // End of FlagInfoCollection class
} // End of namespace
