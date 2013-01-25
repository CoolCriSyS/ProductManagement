// <fileinfo name="SAPFileCheckCollection.cs">
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
	public class SAPFileCheckCollection : SAPFileCheckCollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageDataCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
        internal SAPFileCheckCollection(B2BProductCatalog db)
				: base(db)
		{
			// EMPTY
		}

        public SAPFileCheckRow GetByFileType(string fileType, string locale)
        {
            string whereSql = string.Format("[FileType]={0} AND [Locale]={1}",
                              Database.CreateSqlParameterName("FileType"),
                              Database.CreateSqlParameterName("Locale"));
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "FileType", fileType);
            AddParameter(cmd, "Locale", locale);
            SAPFileCheckRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }
	} // End of ImageDataCollection class
} // End of namespace
