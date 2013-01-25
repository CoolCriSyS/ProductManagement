// <fileinfo name="ImageDataRow_Base.cs">
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
	/// The base class for <see cref="ImageDataRow"/> that 
	/// represents a record in the <c>ImageData</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ImageDataRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ImageDataRow_Base
	{
		private int _pkId;
		private string _stockNumber;
		private System.DateTime _createdOn;
		private string _url;
		private string _fileName;
		private int _size;
		private bool _sizeNull = true;
		private int _mediaType;
		private bool _mediaTypeNull = true;
	    private string _locale;

		/// <summary>
		/// Initializes a new instance of the <see cref="ImageDataRow_Base"/> class.
		/// </summary>
		public ImageDataRow_Base()
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
		/// Gets or sets the <c>StockNumber</c> column value.
		/// </summary>
		/// <value>The <c>StockNumber</c> column value.</value>
		public string StockNumber
		{
			get { return _stockNumber; }
			set { _stockNumber = value; }
		}

		/// <summary>
		/// Gets or sets the <c>CreatedOn</c> column value.
		/// </summary>
		/// <value>The <c>CreatedOn</c> column value.</value>
		public System.DateTime CreatedOn
		{
			get { return _createdOn; }
			set { _createdOn = value; }
		}

		/// <summary>
		/// Gets or sets the <c>Url</c> column value.
		/// </summary>
		/// <value>The <c>Url</c> column value.</value>
		public string Url
		{
			get { return _url; }
			set { _url = value; }
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
		/// Gets or sets the <c>Size</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>Size</c> column value.</value>
		public int Size
		{
			get
			{
				if(IsSizeNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _size;
			}
			set
			{
				_sizeNull = false;
				_size = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="Size"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSizeNull
		{
			get { return _sizeNull; }
			set { _sizeNull = value; }
		}

		/// <summary>
		/// Gets or sets the <c>MediaType</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MediaType</c> column value.</value>
		public int MediaType
		{
			get
			{
				if(IsMediaTypeNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _mediaType;
			}
			set
			{
				_mediaTypeNull = false;
				_mediaType = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MediaType"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMediaTypeNull
		{
			get { return _mediaTypeNull; }
			set { _mediaTypeNull = value; }
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
			dynStr.Append("  StockNumber=");
			dynStr.Append(StockNumber);
			dynStr.Append("  CreatedOn=");
			dynStr.Append(CreatedOn);
			dynStr.Append("  Url=");
			dynStr.Append(Url);
			dynStr.Append("  FileName=");
			dynStr.Append(FileName);
			dynStr.Append("  Size=");
			dynStr.Append(IsSizeNull ? (object)"<NULL>" : Size);
			dynStr.Append("  MediaType=");
			dynStr.Append(IsMediaTypeNull ? (object)"<NULL>" : MediaType);
            dynStr.Append("  Locale=");
            dynStr.Append(Locale);
			return dynStr.ToString();
		}
	} // End of ImageDataRow_Base class
} // End of namespace
