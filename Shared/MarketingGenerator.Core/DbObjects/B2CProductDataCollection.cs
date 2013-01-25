// <fileinfo name="B2CProductDataCollection.cs">
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
	/// Represents the <c>B2CProductData</c> table.
	/// </summary>
	public class B2CProductDataCollection : B2CProductDataCollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="B2CProductDataCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal B2CProductDataCollection(B2BProductCatalog db)
				: base(db)
		{
			// EMPTY
		}

        public B2CProductDataRow GetByStyleNumber(string styleNumber)
        {
            string whereSql = "[StyleNumber]=" + Database.CreateSqlParameterName("StyleNumber");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "StyleNumber", styleNumber);
            B2CProductDataRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }
	} // End of B2CProductDataCollection class
} // End of namespace
