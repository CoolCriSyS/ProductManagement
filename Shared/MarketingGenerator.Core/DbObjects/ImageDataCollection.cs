// <fileinfo name="ImageDataCollection.cs">
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
	/// Represents the <c>ImageData</c> table.
	/// </summary>
	public class ImageDataCollection : ImageDataCollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageDataCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal ImageDataCollection(B2BProductCatalog db)
				: base(db)
		{
			// EMPTY
		}

        public ImageDataRow GetByStockNumber(string stockNumber, string locale)
        {
            string whereSql = "[StockNumber]=" + Database.CreateSqlParameterName("StockNumber") +
                " AND [Locale]=" + Database.CreateSqlParameterName("Locale");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "StockNumber", stockNumber);
            AddParameter(cmd, "Locale", locale);
            ImageDataRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }
	} // End of ImageDataCollection class
} // End of namespace
