// <fileinfo name="ImageDataCollection_Base.cs">
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
	/// The base class for <see cref="ImageDataCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ImageDataCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ImageDataCollection_Base
	{
		// Constants
		public const string PkIdColumnName = "pkId";
		public const string StockNumberColumnName = "StockNumber";
		public const string CreatedOnColumnName = "CreatedOn";
		public const string UrlColumnName = "Url";
		public const string FileNameColumnName = "FileName";
		public const string SizeColumnName = "Size";
		public const string MediaTypeColumnName = "MediaType";
	    public const string LocaleColumnName = "Locale";

		// Instance fields
		private B2BProductCatalog _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ImageDataCollection_Base"/> 
		/// class with the specified <see cref="B2BProductCatalog"/>.
		/// </summary>
		/// <param name="db">The <see cref="B2BProductCatalog"/> object.</param>
		public ImageDataCollection_Base(B2BProductCatalog db)
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
		/// Gets an array of all records from the <c>ImageData</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ImageDataRow"/> objects.</returns>
		public virtual ImageDataRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ImageData</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ImageData</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ImageDataRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ImageDataRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ImageDataRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ImageDataRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ImageDataRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ImageDataRow"/> objects.</returns>
		public ImageDataRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ImageDataRow"/> objects that 
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
		/// <returns>An array of <see cref="ImageDataRow"/> objects.</returns>
		public virtual ImageDataRow[] GetAsArray(string whereSql, string orderBySql,
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
			string sql = "SELECT * FROM [dbo].[ImageData]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ImageDataRow"/> by the primary key.
		/// </summary>
		/// <param name="pkId">The <c>pkId</c> column value.</param>
		/// <returns>An instance of <see cref="ImageDataRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ImageDataRow GetByPrimaryKey(int pkId)
		{
			string whereSql = "[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PkId", pkId);
			ImageDataRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>ImageData</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ImageDataRow"/> object to be inserted.</param>
		public virtual void Insert(ImageDataRow value)
		{
			string sqlStr = "INSERT INTO [dbo].[ImageData] (" +
				"[StockNumber], " +
				"[CreatedOn], " +
				"[Url], " +
				"[FileName], " +
				"[Size], " +
				"[MediaType], " +
                "[Locale]" +
				") VALUES (" +
				_db.CreateSqlParameterName("StockNumber") + ", " +
				_db.CreateSqlParameterName("CreatedOn") + ", " +
				_db.CreateSqlParameterName("Url") + ", " +
				_db.CreateSqlParameterName("FileName") + ", " +
				_db.CreateSqlParameterName("Size") + ", " +
                _db.CreateSqlParameterName("MediaType") + ", " +
                _db.CreateSqlParameterName("Locale") +  ");SELECT @@IDENTITY";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "StockNumber", value.StockNumber);
			AddParameter(cmd, "CreatedOn", value.CreatedOn);
			AddParameter(cmd, "Url", value.Url);
			AddParameter(cmd, "FileName", value.FileName);
			AddParameter(cmd, "Size",
				value.IsSizeNull ? DBNull.Value : (object)value.Size);
			AddParameter(cmd, "MediaType",
				value.IsMediaTypeNull ? DBNull.Value : (object)value.MediaType);
            AddParameter(cmd, "Locale", value.Locale);
			value.PkId = Convert.ToInt32(cmd.ExecuteScalar());
		}

		/// <summary>
		/// Updates a record in the <c>ImageData</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ImageDataRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ImageDataRow value)
		{
			string sqlStr = "UPDATE [dbo].[ImageData] SET " +
				"[StockNumber]=" + _db.CreateSqlParameterName("StockNumber") + ", " +
				"[CreatedOn]=" + _db.CreateSqlParameterName("CreatedOn") + ", " +
				"[Url]=" + _db.CreateSqlParameterName("Url") + ", " +
				"[FileName]=" + _db.CreateSqlParameterName("FileName") + ", " +
				"[Size]=" + _db.CreateSqlParameterName("Size") + ", " +
				"[MediaType]=" + _db.CreateSqlParameterName("MediaType") + ", " +
                "[Locale]=" + _db.CreateSqlParameterName("Locale") +
				" WHERE " +
				"[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "StockNumber", value.StockNumber);
			AddParameter(cmd, "CreatedOn", value.CreatedOn);
			AddParameter(cmd, "Url", value.Url);
			AddParameter(cmd, "FileName", value.FileName);
			AddParameter(cmd, "Size",
				value.IsSizeNull ? DBNull.Value : (object)value.Size);
			AddParameter(cmd, "MediaType",
				value.IsMediaTypeNull ? DBNull.Value : (object)value.MediaType);
            AddParameter(cmd, "Locale", value.Locale);
			AddParameter(cmd, "PkId", value.PkId);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ImageData</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ImageData</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
		/// argument when your code calls this method in an ADO.NET transaction context. Note that in 
		/// this case, after you call the Update method you need call either <c>AcceptChanges</c> 
		/// or <c>RejectChanges</c> method on the DataTable object.
		/// <code>
		/// MyDb db = new MyDb();
		/// try
		/// {
		///		db.BeginTransaction();
		///		db.MyCollection.Update(myDataTable, false);
		///		db.CommitTransaction();
		///		myDataTable.AcceptChanges();
		/// }
		/// catch(Exception)
		/// {
		///		db.RollbackTransaction();
		///		myDataTable.RejectChanges();
		/// }
		/// </code>
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		/// <param name="acceptChanges">Specifies whether this method calls the <c>AcceptChanges</c>
		/// method on the changed DataRow objects.</param>
		public virtual void Update(DataTable table, bool acceptChanges)
		{
			DataRowCollection rows = table.Rows;
			for(int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow row = rows[i];
				switch(row.RowState)
				{
					case DataRowState.Added:
						Insert(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;

					case DataRowState.Deleted:
						// Temporary reject changes to be able to access to the PK column(s)
						row.RejectChanges();
						try
						{
							DeleteByPrimaryKey((int)row["PkId"]);
						}
						finally
						{
							row.Delete();
						}
						if(acceptChanges)
							row.AcceptChanges();
						break;
						
					case DataRowState.Modified:
						Update(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;
				}
			}
		}

		/// <summary>
		/// Deletes the specified object from the <c>ImageData</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ImageDataRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ImageDataRow value)
		{
			return DeleteByPrimaryKey(value.PkId);
		}

		/// <summary>
		/// Deletes a record from the <c>ImageData</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="pkId">The <c>pkId</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(int pkId)
		{
			string whereSql = "[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PkId", pkId);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes <c>ImageData</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>ImageData</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			string sql = "DELETE FROM [dbo].[ImageData]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ImageData</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="ImageDataRow"/> objects.</returns>
		protected ImageDataRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ImageDataRow"/> objects.</returns>
		protected ImageDataRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ImageDataRow"/> objects.</returns>
		protected virtual ImageDataRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int pkIdColumnIndex = reader.GetOrdinal("pkId");
			int stockNumberColumnIndex = reader.GetOrdinal("StockNumber");
			int createdOnColumnIndex = reader.GetOrdinal("CreatedOn");
			int urlColumnIndex = reader.GetOrdinal("Url");
			int fileNameColumnIndex = reader.GetOrdinal("FileName");
			int sizeColumnIndex = reader.GetOrdinal("Size");
			int mediaTypeColumnIndex = reader.GetOrdinal("MediaType");
            int localeColumnIndex = reader.GetOrdinal("Locale");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ImageDataRow record = new ImageDataRow();
					recordList.Add(record);

					record.PkId = Convert.ToInt32(reader.GetValue(pkIdColumnIndex));
					record.StockNumber = Convert.ToString(reader.GetValue(stockNumberColumnIndex));
					record.CreatedOn = Convert.ToDateTime(reader.GetValue(createdOnColumnIndex));
					record.Url = Convert.ToString(reader.GetValue(urlColumnIndex));
					if(!reader.IsDBNull(fileNameColumnIndex))
						record.FileName = Convert.ToString(reader.GetValue(fileNameColumnIndex));
					if(!reader.IsDBNull(sizeColumnIndex))
						record.Size = Convert.ToInt32(reader.GetValue(sizeColumnIndex));
					if(!reader.IsDBNull(mediaTypeColumnIndex))
						record.MediaType = Convert.ToInt32(reader.GetValue(mediaTypeColumnIndex));
                    if (!reader.IsDBNull(localeColumnIndex))
                        record.Locale = Convert.ToString(reader.GetValue(localeColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ImageDataRow[])(recordList.ToArray(typeof(ImageDataRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ImageDataRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ImageDataRow"/> object.</returns>
		protected virtual ImageDataRow MapRow(DataRow row)
		{
			ImageDataRow mappedObject = new ImageDataRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PkId"
			dataColumn = dataTable.Columns["PkId"];
			if(!row.IsNull(dataColumn))
				mappedObject.PkId = (int)row[dataColumn];
			// Column "StockNumber"
			dataColumn = dataTable.Columns["StockNumber"];
			if(!row.IsNull(dataColumn))
				mappedObject.StockNumber = (string)row[dataColumn];
			// Column "CreatedOn"
			dataColumn = dataTable.Columns["CreatedOn"];
			if(!row.IsNull(dataColumn))
				mappedObject.CreatedOn = (System.DateTime)row[dataColumn];
			// Column "Url"
			dataColumn = dataTable.Columns["Url"];
			if(!row.IsNull(dataColumn))
				mappedObject.Url = (string)row[dataColumn];
			// Column "FileName"
			dataColumn = dataTable.Columns["FileName"];
			if(!row.IsNull(dataColumn))
				mappedObject.FileName = (string)row[dataColumn];
			// Column "Size"
			dataColumn = dataTable.Columns["Size"];
			if(!row.IsNull(dataColumn))
				mappedObject.Size = (int)row[dataColumn];
			// Column "MediaType"
			dataColumn = dataTable.Columns["MediaType"];
			if(!row.IsNull(dataColumn))
				mappedObject.MediaType = (int)row[dataColumn];
            // Column "Locale"
            dataColumn = dataTable.Columns["Locale"];
            if (!row.IsNull(dataColumn))
                mappedObject.Locale = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ImageData</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ImageData";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PkId", typeof(int));
			dataColumn.Caption = "pkId";
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn.Unique = true;
			dataColumn.AutoIncrement = true;
			dataColumn = dataTable.Columns.Add("StockNumber", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CreatedOn", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Url", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FileName", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Size", typeof(int));
			dataColumn = dataTable.Columns.Add("MediaType", typeof(int));
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
				case "PkId":
					parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

				case "StockNumber":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CreatedOn":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "Url":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FileName":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Size":
					parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

				case "MediaType":
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
	} // End of ImageDataCollection_Base class
}  // End of namespace
