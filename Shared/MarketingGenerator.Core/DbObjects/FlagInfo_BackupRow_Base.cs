// <fileinfo name="FlagInfo_BackupRow_Base.cs">
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
	/// The base class for <see cref="FlagInfo_BackupRow"/> that 
	/// represents a record in the <c>FlagInfo_Backup</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FlagInfo_BackupRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FlagInfo_BackupRow_Base
	{
		private int _pkId;
		private string _flagId;
		private string _flagName;
		private string _flagNameFr;
		private string _flagDescription;
		private string _flagDescriptionFr;
		private string _category;
		private string _fileName;
		private string _salesOrg;
		private string _distributionChannel;
		private int _sequence;
		private bool _sequenceNull = true;
		private System.DateTime _createdOn;
		private bool _createdOnNull = true;
		private System.DateTime _updatedOn;
		private bool _updatedOnNull = true;
	    private string _locale;

		/// <summary>
		/// Initializes a new instance of the <see cref="FlagInfo_BackupRow_Base"/> class.
		/// </summary>
		public FlagInfo_BackupRow_Base()
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
		/// Gets or sets the <c>FlagId</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FlagId</c> column value.</value>
		public string FlagId
		{
			get { return _flagId; }
			set { _flagId = value; }
		}

		/// <summary>
		/// Gets or sets the <c>FlagName</c> column value.
		/// </summary>
		/// <value>The <c>FlagName</c> column value.</value>
		public string FlagName
		{
			get { return _flagName; }
			set { _flagName = value; }
		}

		/// <summary>
		/// Gets or sets the <c>FlagNameFr</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FlagNameFr</c> column value.</value>
		public string FlagNameFr
		{
			get { return _flagNameFr; }
			set { _flagNameFr = value; }
		}

		/// <summary>
		/// Gets or sets the <c>FlagDescription</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FlagDescription</c> column value.</value>
		public string FlagDescription
		{
			get { return _flagDescription; }
			set { _flagDescription = value; }
		}

		/// <summary>
		/// Gets or sets the <c>FlagDescriptionFr</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FlagDescriptionFr</c> column value.</value>
		public string FlagDescriptionFr
		{
			get { return _flagDescriptionFr; }
			set { _flagDescriptionFr = value; }
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
		/// Gets or sets the <c>FileName</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FileName</c> column value.</value>
		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
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
		/// Gets or sets the <c>Sequence</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Sequence</c> column value.</value>
		public int Sequence
		{
			get
			{
				if(IsSequenceNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sequence;
			}
			set
			{
				_sequenceNull = false;
				_sequence = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="Sequence"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSequenceNull
		{
			get { return _sequenceNull; }
			set { _sequenceNull = value; }
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
			dynStr.Append("  FlagId=");
			dynStr.Append(FlagId);
			dynStr.Append("  FlagName=");
			dynStr.Append(FlagName);
			dynStr.Append("  FlagNameFr=");
			dynStr.Append(FlagNameFr);
			dynStr.Append("  FlagDescription=");
			dynStr.Append(FlagDescription);
			dynStr.Append("  FlagDescriptionFr=");
			dynStr.Append(FlagDescriptionFr);
			dynStr.Append("  Category=");
			dynStr.Append(Category);
			dynStr.Append("  FileName=");
			dynStr.Append(FileName);
			dynStr.Append("  SalesOrg=");
			dynStr.Append(SalesOrg);
			dynStr.Append("  DistributionChannel=");
			dynStr.Append(DistributionChannel);
			dynStr.Append("  Sequence=");
			dynStr.Append(IsSequenceNull ? (object)"<NULL>" : Sequence);
			dynStr.Append("  CreatedOn=");
			dynStr.Append(IsCreatedOnNull ? (object)"<NULL>" : CreatedOn);
			dynStr.Append("  UpdatedOn=");
			dynStr.Append(IsUpdatedOnNull ? (object)"<NULL>" : UpdatedOn);
            dynStr.Append("  Locale=");
            dynStr.Append(Locale);
			return dynStr.ToString();
		}
	} // End of FlagInfo_BackupRow_Base class
} // End of namespace
