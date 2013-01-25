// <fileinfo name="BrandCollection.cs">
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
	/// Represents the <c>Brand</c> table.
	/// </summary>
	public class BrandCollection : BrandCollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BrandCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal BrandCollection(B2BProductCatalog db)
				: base(db)
		{
			// EMPTY
		}
	} // End of BrandCollection class
} // End of namespace
