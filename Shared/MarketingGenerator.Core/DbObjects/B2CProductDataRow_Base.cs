// <fileinfo name="B2CProductDataRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace MarketingGenerator.Core.DbObjects
{
	/// <summary>
	/// The base class for <see cref="B2CProductDataRow"/> that 
	/// represents a record in the <c>B2CProductData</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="B2CProductDataRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class B2CProductDataRow_Base
	{
		private int _pkID;
		private string _styleNumber;
		private string _productName;
		private string _brandName;
		private string _productDescEn;
		private string _productDescFr;

		/// <summary>
		/// Initializes a new instance of the <see cref="B2CProductDataRow_Base"/> class.
		/// </summary>
		public B2CProductDataRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Gets or sets the <c>PkID</c> column value.
		/// </summary>
		/// <value>The <c>PkID</c> column value.</value>
		public int PkID
		{
			get { return _pkID; }
			set { _pkID = value; }
		}

		/// <summary>
		/// Gets or sets the <c>StyleNumber</c> column value.
		/// </summary>
		/// <value>The <c>StyleNumber</c> column value.</value>
		public string StyleNumber
		{
			get { return _styleNumber; }
			set { _styleNumber = value; }
		}

		/// <summary>
		/// Gets or sets the <c>ProductName</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ProductName</c> column value.</value>
		public string ProductName
		{
			get { return _productName; }
			set { _productName = value; }
		}

		/// <summary>
		/// Gets or sets the <c>BrandName</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BrandName</c> column value.</value>
		public string BrandName
		{
			get { return _brandName; }
			set { _brandName = value; }
		}

		/// <summary>
		/// Gets or sets the <c>ProductDescEn</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ProductDescEn</c> column value.</value>
		public string ProductDescEn
		{
			get { return _productDescEn; }
			set { _productDescEn = value; }
		}

		/// <summary>
		/// Gets or sets the <c>ProductDescFr</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ProductDescFr</c> column value.</value>
		public string ProductDescFr
		{
			get { return _productDescFr; }
			set { _productDescFr = value; }
		}

		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("  PkID=");
			dynStr.Append(PkID);
			dynStr.Append("  StyleNumber=");
			dynStr.Append(StyleNumber);
			dynStr.Append("  ProductName=");
			dynStr.Append(ProductName);
			dynStr.Append("  BrandName=");
			dynStr.Append(BrandName);
			dynStr.Append("  ProductDescEn=");
			dynStr.Append(ProductDescEn);
			dynStr.Append("  ProductDescFr=");
			dynStr.Append(ProductDescFr);
			return dynStr.ToString();
		}
	} // End of B2CProductDataRow_Base class
} // End of namespace
