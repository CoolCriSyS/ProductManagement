// <fileinfo name="SAPFileCheckCollection_Base.cs">
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
using System.Data;

namespace MarketingGenerator.Core.DbObjects
{
	/// <summary>
	/// The base class for <see cref="SAPFileCheckCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="SAPFileCheckCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class SAPFileCheckCollection_Base
	{
		// Constants
		public const string FileTypeColumnName = "FileType";
		public const string ThresholdColumnName = "Threshold";
		public const string PreviousLineCountColumnName = "PreviousLineCount";
		public const string CurrentLineCountColumnName = "CurrentLineCount";
	    public const string LocaleColumnName = "Locale";

		// Instance fields
		private B2BProductCatalog _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="SAPFileCheckCollection_Base"/> 
		/// class with the specified <see cref="B2BProductCatalog"/>.
		/// </summary>
		/// <param name="db">The <see cref="B2BProductCatalog"/> object.</param>
		public SAPFileCheckCollection_Base(B2BProductCatalog db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="B2BProductCatalog"/> object.</value>
		protected B2BProductCatalog Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>SAPFileCheck</c> table.
		/// </summary>
		/// <returns>An array of <see cref="SAPFileCheckRow"/> objects.</returns>
		public virtual SAPFileCheckRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>SAPFileCheck</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>SAPFileCheck</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="SAPFileCheckRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="SAPFileCheckRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public SAPFileCheckRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			SAPFileCheckRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="SAPFileCheckRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SAPFileCheckRow"/> objects.</returns>
		public SAPFileCheckRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="SAPFileCheckRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example:
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <param name="startIndex">The index of the first record to return.</param>
		/// <param name="length">The number of records to return.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="SAPFileCheckRow"/> objects.</returns>
		public virtual SAPFileCheckRow[] GetAsArray(string whereSql, string orderBySql,
							int startIndex, int length, ref int totalRecordCount)
		{
			using(IDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object filled with data that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetAsDataTable(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsDataTable(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object filled with data that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <param name="startIndex">The index of the first record to return.</param>
		/// <param name="length">The number of records to return.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAsDataTable(string whereSql, string orderBySql,
							int startIndex, int length, ref int totalRecordCount)
		{
			using(IDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
			{
				return MapRecordsToDataTable(reader, startIndex, length, ref totalRecordCount);
			}
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object for the specified search criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			string sql = "SELECT * FROM [dbo].[SAPFileCheck]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

        /// <summary>
        /// Updates a record in the <c>SAPFileCheck</c> table.
        /// </summary>
        /// <param name="value">The <see cref="SAPFileCheckRow"/>
        /// object used to update the table record.</param>
        /// <returns>true if the record was updated; otherwise, false.</returns>
        public virtual bool Update(SAPFileCheckRow value)
        {
            string sqlStr = "UPDATE [dbo].[SAPFileCheck] SET " +
                "[PreviousLineCount]=" + _db.CreateSqlParameterName("PreviousLineCount") + ", " +
                "[CurrentLineCount]=" + _db.CreateSqlParameterName("PreviousLineCount") +
                " WHERE " +
                "[FileType]=" + _db.CreateSqlParameterName("FileType") + " AND " + 
                "[Locale]=" + _db.CreateSqlParameterName("Locale");
            IDbCommand cmd = _db.CreateCommand(sqlStr);
            AddParameter(cmd, "PreviousLineCount", value.PreviousLineCount);
            AddParameter(cmd, "CurrentLineCount", value.CurrentLineCount);
            AddParameter(cmd, "FileType", value.FileType);
            AddParameter(cmd, "Locale", value.Locale);
            return 0 != cmd.ExecuteNonQuery();
        }

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="SAPFileCheckRow"/> objects.</returns>
		protected SAPFileCheckRow[] MapRecords(IDbCommand command)
		{
			using(IDataReader reader = _db.ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="SAPFileCheckRow"/> objects.</returns>
		protected SAPFileCheckRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="SAPFileCheckRow"/> objects.</returns>
		protected virtual SAPFileCheckRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int fileTypeColumnIndex = reader.GetOrdinal("FileType");
			int thresholdColumnIndex = reader.GetOrdinal("Threshold");
			int previousLineCountColumnIndex = reader.GetOrdinal("PreviousLineCount");
			int currentLineCountColumnIndex = reader.GetOrdinal("CurrentLineCount");
			int localeColumnIndex = reader.GetOrdinal("Locale");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					SAPFileCheckRow record = new SAPFileCheckRow();
					recordList.Add(record);

					record.FileType = Convert.ToString(reader.GetValue(fileTypeColumnIndex));
					record.Threshold = Convert.ToInt32(reader.GetValue(thresholdColumnIndex));
                    if (!reader.IsDBNull(previousLineCountColumnIndex))
					    record.PreviousLineCount = Convert.ToInt32(reader.GetValue(previousLineCountColumnIndex));
                    if (!reader.IsDBNull(currentLineCountColumnIndex))
					    record.CurrentLineCount = Convert.ToInt32(reader.GetValue(currentLineCountColumnIndex));
                    record.Locale = Convert.ToString(reader.GetValue(localeColumnIndex));
					
					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SAPFileCheckRow[])(recordList.ToArray(typeof(SAPFileCheckRow)));
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected DataTable MapRecordsToDataTable(IDbCommand command)
		{
			using(IDataReader reader = _db.ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader);
			}
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected DataTable MapRecordsToDataTable(IDataReader reader)
		{
			int totalRecordCount = 0;
			return MapRecordsToDataTable(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		
		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to read.</param>
		/// <param name="length">The number of records to read.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable MapRecordsToDataTable(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int columnCount = reader.FieldCount;
			int ri = -startIndex;
			
			DataTable dataTable = CreateDataTable();
			dataTable.BeginLoadData();
			object[] values = new object[columnCount];

			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					reader.GetValues(values);
					dataTable.LoadDataRow(values, true);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}
			dataTable.EndLoadData();

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return dataTable;
		}

		/// <summary>
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="SAPFileCheckRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="SAPFileCheckRow"/> object.</returns>
		protected virtual SAPFileCheckRow MapRow(DataRow row)
		{
			SAPFileCheckRow mappedObject = new SAPFileCheckRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "FileType"
			dataColumn = dataTable.Columns["FileType"];
			if(!row.IsNull(dataColumn))
				mappedObject.FileType = (string)row[dataColumn];
			// Column "Threshold"
			dataColumn = dataTable.Columns["Threshold"];
			if(!row.IsNull(dataColumn))
				mappedObject.Threshold = (int)row[dataColumn];
			// Column "PreviousLineCount"
            dataColumn = dataTable.Columns["PreviousLineCount"];
			if(!row.IsNull(dataColumn))
                mappedObject.PreviousLineCount = (int)row[dataColumn];
            // Column "CurrentLineCount"
            dataColumn = dataTable.Columns["CurrentLineCount"];
			if(!row.IsNull(dataColumn))
                mappedObject.CurrentLineCount = (int)row[dataColumn];
            // Column "Locale"
            dataColumn = dataTable.Columns["Locale"];
            if (!row.IsNull(dataColumn))
                mappedObject.FileType = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>SAPFileCheck</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "SAPFileCheck";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FileType", typeof(string));
			dataColumn.MaxLength = 6;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Threshold", typeof(int));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PreviousLineCount", typeof(int));
			dataColumn = dataTable.Columns.Add("CurrentLineCount", typeof(int));
            dataColumn = dataTable.Columns.Add("Locale", typeof(string));
			return dataTable;
		}
		
		/// <summary>
		/// Adds a new parameter to the specified command.
		/// </summary>
		/// <param name="cmd">The <see cref="System.Data.IDbCommand"/> object to add the parameter to.</param>
		/// <param name="paramName">The name of the parameter.</param>
		/// <param name="value">The value of the parameter.</param>
		/// <returns>A reference to the added parameter.</returns>
		protected virtual IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value)
		{
			IDbDataParameter parameter;
			switch(paramName)
			{
				case "FileType":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Threshold":
                    parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

				case "PreviousLineCount":
                    parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

				case "CurrentLineCount":
                    parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

                case "Locale":
                    parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of SAPFileCheckCollection_Base class
}  // End of namespace
