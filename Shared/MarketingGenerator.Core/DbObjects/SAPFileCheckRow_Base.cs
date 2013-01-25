// <fileinfo name="SAPFileCheckRow_Base.cs">
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
	/// The base class for <see cref="SAPFileCheckRow"/> that 
	/// represents a record in the <c>SAPFileCheck</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="SAPFileCheckRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class SAPFileCheckRow_Base
	{
		private string _fileType;
		private int _threshold;
		private int _previousLineCount;
		private int _currentLineCount;
	    private string _locale;

		/// <summary>
		/// Initializes a new instance of the <see cref="SAPFileCheckRow_Base"/> class.
		/// </summary>
		public SAPFileCheckRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Gets or sets the <c>FileType</c> column value.
		/// </summary>
		/// <value>The <c>FileType</c> column value.</value>
		public string FileType
		{
			get { return _fileType; }
			set { _fileType = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Threshold</c> column value.
		/// </summary>
        /// <value>The <c>Threshold</c> column value.</value>
        public int Threshold
		{
			get { return _threshold; }
			set { _threshold = value; }
		}

		/// <summary>
		/// Gets or sets the <c>PreviousLineCount</c> column value.
		/// </summary>
        /// <value>The <c>PreviousLineCount</c> column value.</value>
        public int PreviousLineCount
		{
			get { return _previousLineCount; }
			set { _previousLineCount = value; }
		}

		/// <summary>
        /// Gets or sets the <c>CurrentLineCount</c> column value.
		/// This column is nullable.
		/// </summary>
        /// <value>The <c>CurrentLineCount</c> column value.</value>
        public int CurrentLineCount
		{
			get { return _currentLineCount; }
			set { _currentLineCount = value; }
		}

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
			dynStr.Append("  FileType=");
			dynStr.Append(FileType);
			dynStr.Append("  Threshold=");
			dynStr.Append(Threshold);
			dynStr.Append("  PreviousLineCount=");
            dynStr.Append(PreviousLineCount);
            dynStr.Append("  CurrentLineCount=");
            dynStr.Append(CurrentLineCount);
            dynStr.Append("  Locale=");
            dynStr.Append(Locale);
			return dynStr.ToString();
		}
	} // End of SAPFileCheckRow_Base class
} // End of namespace
