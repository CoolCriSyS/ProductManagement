// <fileinfo name="B2CProductDataRow.cs">
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

namespace MarketingGenerator.Core.DbObjects
{
	/// <summary>
	/// Represents a record in the <c>B2CProductData</c> table.
	/// </summary>
	public class B2CProductDataRow : B2CProductDataRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="B2CProductDataRow"/> class.
		/// </summary>
		public B2CProductDataRow()
		{
			// EMPTY
		}
	
		public void Insert()
		{
			using (B2BProductCatalog database = new B2BProductCatalog())
			{
				database.B2CProductDataCollection.Insert(this);
			}
		}
		
		public void Save()
		{
			using (B2BProductCatalog database = new B2BProductCatalog())
			{
				database.B2CProductDataCollection.Update(this);
			}
		}
		
		


	} // End of B2CProductDataRow class


} // End of namespace


