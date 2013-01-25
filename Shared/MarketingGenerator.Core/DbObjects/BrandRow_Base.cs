// <fileinfo name="BrandRow_Base.cs">
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
	/// The base class for <see cref="BrandRow"/> that 
	/// represents a record in the <c>Brand</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="BrandRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class BrandRow_Base
	{
		private int _pkID;
		private string _brandName;
		private string _b2CBrandName;
		private string _salesOrg;
		private string _dc;

		/// <summary>
		/// Initializes a new instance of the <see cref="BrandRow_Base"/> class.
		/// </summary>
		public BrandRow_Base()
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
		/// Gets or sets the <c>BrandName</c> column value.
		/// </summary>
		/// <value>The <c>BrandName</c> column value.</value>
		public string BrandName
		{
			get { return _brandName; }
			set { _brandName = value; }
		}

		/// <summary>
		/// Gets or sets the <c>B2CBrandName</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>B2CBrandName</c> column value.</value>
		public string B2CBrandName
		{
			get { return _b2CBrandName; }
			set { _b2CBrandName = value; }
		}

		/// <summary>
		/// Gets or sets the <c>SalesOrg</c> column value.
		/// </summary>
		/// <value>The <c>SalesOrg</c> column value.</value>
		public string SalesOrg
		{
			get { return _salesOrg; }
			set { _salesOrg = value; }
		}

		/// <summary>
		/// Gets or sets the <c>DC</c> column value.
		/// </summary>
		/// <value>The <c>DC</c> column value.</value>
		public string DC
		{
			get { return _dc; }
			set { _dc = value; }
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
			dynStr.Append("  BrandName=");
			dynStr.Append(BrandName);
			dynStr.Append("  B2CBrandName=");
			dynStr.Append(B2CBrandName);
			dynStr.Append("  SalesOrg=");
			dynStr.Append(SalesOrg);
			dynStr.Append("  DC=");
			dynStr.Append(DC);
			return dynStr.ToString();
		}
	} // End of BrandRow_Base class
} // End of namespace
