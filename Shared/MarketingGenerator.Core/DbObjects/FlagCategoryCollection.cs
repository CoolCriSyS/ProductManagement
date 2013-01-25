// <fileinfo name="FlagCategoryCollection.cs">
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
	/// Represents the <c>FlagCategory</c> table.
	/// </summary>
	public class FlagCategoryCollection : FlagCategoryCollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FlagCategoryCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal FlagCategoryCollection(B2BProductCatalog db)
				: base(db)
		{
			// EMPTY
		}

        public FlagCategoryRow GetByFlagCategory(string flagCategory, string salesOrg, string distChan, string locale)
        {
            string whereSql = "[Category]=" + Database.CreateSqlParameterName("Category") + " AND [SalesOrg]=" + 
                Database.CreateSqlParameterName("SalesOrg") + " AND [DistributionChannel]=" + 
                Database.CreateSqlParameterName("DistributionChannel") + " AND [Locale]=" +
                Database.CreateSqlParameterName("Locale");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "Category", flagCategory);
            AddParameter(cmd, "SalesOrg", salesOrg);
            AddParameter(cmd, "DistributionChannel", distChan);
            AddParameter(cmd, "Locale", locale);
            FlagCategoryRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }
	} // End of FlagCategoryCollection class
} // End of namespace
