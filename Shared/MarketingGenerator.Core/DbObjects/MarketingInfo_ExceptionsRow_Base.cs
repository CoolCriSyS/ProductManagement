// <fileinfo name="MarketingInfo_ExceptionsRow_Base.cs">
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
	/// The base class for <see cref="MarketingInfo_ExceptionsRow"/> that 
	/// represents a record in the <c>MarketingInfo_Exceptions</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MarketingInfo_ExceptionsRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MarketingInfo_ExceptionsRow_Base
	{
		private int _pkId;
		private string _styleNumber;
		private string _salesOrg;
		private string _distributionChannel;
		private string _marketingDescEn;
		private string _marketingDescFr;
		private string _styleKeywords;
		private string _styleSizeRun;
		private string _navCategory1;
		private string _navCategory2;
		private string _navCategory3;
		private string _navCategory4;
		private string _navCategoryFr1;
		private string _navCategoryFr2;
		private string _navCategoryFr3;
		private string _navCategoryFr4;
		private string _flag1;
		private string _flag2;
		private string _flag3;
		private string _flag4;
		private string _flag5;
		private string _flag6;
		private string _flag7;
		private string _flag8;
		private string _flag9;
		private string _flag10;
		private string _flag11;
		private string _flag12;
		private System.DateTime _createdOn;
		private bool _createdOnNull = true;
		private System.DateTime _updatedOn;
		private bool _updatedOnNull = true;
	    private string _locale;

		/// <summary>
		/// Initializes a new instance of the <see cref="MarketingInfo_ExceptionsRow_Base"/> class.
		/// </summary>
		public MarketingInfo_ExceptionsRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Gets or sets the <c>pkId</c> column value.
		/// </summary>
		/// <value>The <c>pkId</c> column value.</value>
		public int PkId
		{
			get { return _pkId; }
			set { _pkId = value; }
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
		/// Gets or sets the <c>SalesOrg</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SalesOrg</c> column value.</value>
		public string SalesOrg
		{
			get { return _salesOrg; }
			set { _salesOrg = value; }
		}

		/// <summary>
		/// Gets or sets the <c>DistributionChannel</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DistributionChannel</c> column value.</value>
		public string DistributionChannel
		{
			get { return _distributionChannel; }
			set { _distributionChannel = value; }
		}

		/// <summary>
		/// Gets or sets the <c>MarketingDescEn</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MarketingDescEn</c> column value.</value>
		public string MarketingDescEn
		{
			get { return _marketingDescEn; }
			set { _marketingDescEn = value; }
		}

		/// <summary>
		/// Gets or sets the <c>MarketingDescFr</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MarketingDescFr</c> column value.</value>
		public string MarketingDescFr
		{
			get { return _marketingDescFr; }
			set { _marketingDescFr = value; }
		}

		/// <summary>
		/// Gets or sets the <c>StyleKeywords</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>StyleKeywords</c> column value.</value>
		public string StyleKeywords
		{
			get { return _styleKeywords; }
			set { _styleKeywords = value; }
		}

		/// <summary>
		/// Gets or sets the <c>StyleSizeRun</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>StyleSizeRun</c> column value.</value>
		public string StyleSizeRun
		{
			get { return _styleSizeRun; }
			set { _styleSizeRun = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategory1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategory1</c> column value.</value>
		public string NavCategory1
		{
			get { return _navCategory1; }
			set { _navCategory1 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategory2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategory2</c> column value.</value>
		public string NavCategory2
		{
			get { return _navCategory2; }
			set { _navCategory2 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategory3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategory3</c> column value.</value>
		public string NavCategory3
		{
			get { return _navCategory3; }
			set { _navCategory3 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategory4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategory4</c> column value.</value>
		public string NavCategory4
		{
			get { return _navCategory4; }
			set { _navCategory4 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategoryFr1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategoryFr1</c> column value.</value>
		public string NavCategoryFr1
		{
			get { return _navCategoryFr1; }
			set { _navCategoryFr1 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategoryFr2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategoryFr2</c> column value.</value>
		public string NavCategoryFr2
		{
			get { return _navCategoryFr2; }
			set { _navCategoryFr2 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategoryFr3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategoryFr3</c> column value.</value>
		public string NavCategoryFr3
		{
			get { return _navCategoryFr3; }
			set { _navCategoryFr3 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>NavCategoryFr4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NavCategoryFr4</c> column value.</value>
		public string NavCategoryFr4
		{
			get { return _navCategoryFr4; }
			set { _navCategoryFr4 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag1</c> column value.</value>
		public string Flag1
		{
			get { return _flag1; }
			set { _flag1 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag2</c> column value.</value>
		public string Flag2
		{
			get { return _flag2; }
			set { _flag2 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag3</c> column value.</value>
		public string Flag3
		{
			get { return _flag3; }
			set { _flag3 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag4</c> column value.</value>
		public string Flag4
		{
			get { return _flag4; }
			set { _flag4 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag5</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag5</c> column value.</value>
		public string Flag5
		{
			get { return _flag5; }
			set { _flag5 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag6</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag6</c> column value.</value>
		public string Flag6
		{
			get { return _flag6; }
			set { _flag6 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag7</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag7</c> column value.</value>
		public string Flag7
		{
			get { return _flag7; }
			set { _flag7 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag8</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag8</c> column value.</value>
		public string Flag8
		{
			get { return _flag8; }
			set { _flag8 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag9</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag9</c> column value.</value>
		public string Flag9
		{
			get { return _flag9; }
			set { _flag9 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag10</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag10</c> column value.</value>
		public string Flag10
		{
			get { return _flag10; }
			set { _flag10 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag11</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag11</c> column value.</value>
		public string Flag11
		{
			get { return _flag11; }
			set { _flag11 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Flag12</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Flag12</c> column value.</value>
		public string Flag12
		{
			get { return _flag12; }
			set { _flag12 = value; }
		}

		/// <summary>
		/// Gets or sets the <c>CreatedOn</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CreatedOn</c> column value.</value>
		public System.DateTime CreatedOn
		{
			get
			{
				if(IsCreatedOnNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _createdOn;
			}
			set
			{
				_createdOnNull = false;
				_createdOn = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CreatedOn"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCreatedOnNull
		{
			get { return _createdOnNull; }
			set { _createdOnNull = value; }
		}

		/// <summary>
		/// Gets or sets the <c>UpdatedOn</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UpdatedOn</c> column value.</value>
		public System.DateTime UpdatedOn
		{
			get
			{
				if(IsUpdatedOnNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _updatedOn;
			}
			set
			{
				_updatedOnNull = false;
				_updatedOn = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="UpdatedOn"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUpdatedOnNull
		{
			get { return _updatedOnNull; }
			set { _updatedOnNull = value; }
		}

        /// <summary>
        /// Gets or sets the <c>Locale</c> column value.
        /// This column is nullable.
        /// </summary>
        /// <value>The <c>Locale</c> column value.</value>
        public string Locale
        {
            get { return _locale; }
            set { _locale = value; }
        }

		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("  PkId=");
			dynStr.Append(PkId);
			dynStr.Append("  StyleNumber=");
			dynStr.Append(StyleNumber);
			dynStr.Append("  SalesOrg=");
			dynStr.Append(SalesOrg);
			dynStr.Append("  DistributionChannel=");
			dynStr.Append(DistributionChannel);
			dynStr.Append("  MarketingDescEn=");
			dynStr.Append(MarketingDescEn);
			dynStr.Append("  MarketingDescFr=");
			dynStr.Append(MarketingDescFr);
			dynStr.Append("  StyleKeywords=");
			dynStr.Append(StyleKeywords);
			dynStr.Append("  StyleSizeRun=");
			dynStr.Append(StyleSizeRun);
			dynStr.Append("  NavCategory1=");
			dynStr.Append(NavCategory1);
			dynStr.Append("  NavCategory2=");
			dynStr.Append(NavCategory2);
			dynStr.Append("  NavCategory3=");
			dynStr.Append(NavCategory3);
			dynStr.Append("  NavCategory4=");
			dynStr.Append(NavCategory4);
			dynStr.Append("  NavCategoryFr1=");
			dynStr.Append(NavCategoryFr1);
			dynStr.Append("  NavCategoryFr2=");
			dynStr.Append(NavCategoryFr2);
			dynStr.Append("  NavCategoryFr3=");
			dynStr.Append(NavCategoryFr3);
			dynStr.Append("  NavCategoryFr4=");
			dynStr.Append(NavCategoryFr4);
			dynStr.Append("  Flag1=");
			dynStr.Append(Flag1);
			dynStr.Append("  Flag2=");
			dynStr.Append(Flag2);
			dynStr.Append("  Flag3=");
			dynStr.Append(Flag3);
			dynStr.Append("  Flag4=");
			dynStr.Append(Flag4);
			dynStr.Append("  Flag5=");
			dynStr.Append(Flag5);
			dynStr.Append("  Flag6=");
			dynStr.Append(Flag6);
			dynStr.Append("  Flag7=");
			dynStr.Append(Flag7);
			dynStr.Append("  Flag8=");
			dynStr.Append(Flag8);
			dynStr.Append("  Flag9=");
			dynStr.Append(Flag9);
			dynStr.Append("  Flag10=");
			dynStr.Append(Flag10);
			dynStr.Append("  Flag11=");
			dynStr.Append(Flag11);
			dynStr.Append("  Flag12=");
			dynStr.Append(Flag12);
			dynStr.Append("  CreatedOn=");
			dynStr.Append(IsCreatedOnNull ? (object)"<NULL>" : CreatedOn);
			dynStr.Append("  UpdatedOn=");
			dynStr.Append(IsUpdatedOnNull ? (object)"<NULL>" : UpdatedOn);
            dynStr.Append("  Locale=");
            dynStr.Append(Locale);
			return dynStr.ToString();
		}
	} // End of MarketingInfo_ExceptionsRow_Base class
} // End of namespace
