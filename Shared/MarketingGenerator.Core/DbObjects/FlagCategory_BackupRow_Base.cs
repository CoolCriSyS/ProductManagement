// <fileinfo name="FlagCategory_BackupRow_Base.cs">
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
	/// The base class for <see cref="FlagCategory_BackupRow"/> that 
	/// represents a record in the <c>FlagCategory_Backup</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FlagCategory_BackupRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FlagCategory_BackupRow_Base
	{
		private int _pkId;
		private string _category;
		private string _categoryFr;
		private string _categoryId;
		private int _sequence;
		private string _salesOrg;
		private string _distributionChannel;
		private System.DateTime _createdOn;
		private bool _createdOnNull = true;
		private System.DateTime _updatedOn;
		private bool _updatedOnNull = true;
	    private string _locale;

		/// <summary>
		/// Initializes a new instance of the <see cref="FlagCategory_BackupRow_Base"/> class.
		/// </summary>
		public FlagCategory_BackupRow_Base()
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
		/// Gets or sets the <c>Category</c> column value.
		/// </summary>
		/// <value>The <c>Category</c> column value.</value>
		public string Category
		{
			get { return _category; }
			set { _category = value; }
		}

		/// <summary>
		/// Gets or sets the <c>CategoryFr</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CategoryFr</c> column value.</value>
		public string CategoryFr
		{
			get { return _categoryFr; }
			set { _categoryFr = value; }
		}

		/// <summary>
		/// Gets or sets the <c>CategoryId</c> column value.
		/// </summary>
		/// <value>The <c>CategoryId</c> column value.</value>
		public string CategoryId
		{
			get { return _categoryId; }
			set { _categoryId = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Sequence</c> column value.
		/// </summary>
		/// <value>The <c>Sequence</c> column value.</value>
		public int Sequence
		{
			get { return _sequence; }
			set { _sequence = value; }
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
		/// Gets or sets the <c>DistributionChannel</c> column value.
		/// </summary>
		/// <value>The <c>DistributionChannel</c> column value.</value>
		public string DistributionChannel
		{
			get { return _distributionChannel; }
			set { _distributionChannel = value; }
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
			dynStr.Append("  Category=");
			dynStr.Append(Category);
			dynStr.Append("  CategoryFr=");
			dynStr.Append(CategoryFr);
			dynStr.Append("  CategoryId=");
			dynStr.Append(CategoryId);
			dynStr.Append("  Sequence=");
			dynStr.Append(Sequence);
			dynStr.Append("  SalesOrg=");
			dynStr.Append(SalesOrg);
			dynStr.Append("  DistributionChannel=");
			dynStr.Append(DistributionChannel);
			dynStr.Append("  CreatedOn=");
			dynStr.Append(IsCreatedOnNull ? (object)"<NULL>" : CreatedOn);
			dynStr.Append("  UpdatedOn=");
			dynStr.Append(IsUpdatedOnNull ? (object)"<NULL>" : UpdatedOn);
            dynStr.Append("  Locale=");
            dynStr.Append(Locale);
			return dynStr.ToString();
		}
	} // End of FlagCategory_BackupRow_Base class
} // End of namespace
