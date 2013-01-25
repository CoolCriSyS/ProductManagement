// <fileinfo name="FlagCategory_ExceptionsCollection_Base.cs">
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
	/// The base class for <see cref="FlagCategory_ExceptionsCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FlagCategory_ExceptionsCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FlagCategory_ExceptionsCollection_Base
	{
		// Constants
		public const string PkIdColumnName = "pkId";
		public const string CategoryColumnName = "Category";
		public const string CategoryFrColumnName = "CategoryFr";
		public const string CategoryIdColumnName = "CategoryId";
		public const string SequenceColumnName = "Sequence";
		public const string SalesOrgColumnName = "SalesOrg";
		public const string DistributionChannelColumnName = "DistributionChannel";
		public const string CreatedOnColumnName = "CreatedOn";
		public const string UpdatedOnColumnName = "UpdatedOn";
	    public const string LocaleColumnName = "Locale";

		// Instance fields
		private B2BProductCatalog _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FlagCategory_ExceptionsCollection_Base"/> 
		/// class with the specified <see cref="B2BProductCatalog"/>.
		/// </summary>
		/// <param name="db">The <see cref="B2BProductCatalog"/> object.</param>
		public FlagCategory_ExceptionsCollection_Base(B2BProductCatalog db)
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
		/// Gets an array of all records from the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FlagCategory_ExceptionsRow"/> objects.</returns>
		public virtual FlagCategory_ExceptionsRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FlagCategory_ExceptionsRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FlagCategory_ExceptionsRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FlagCategory_ExceptionsRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FlagCategory_ExceptionsRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FlagCategory_ExceptionsRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FlagCategory_ExceptionsRow"/> objects.</returns>
		public FlagCategory_ExceptionsRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FlagCategory_ExceptionsRow"/> objects that 
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
		/// <returns>An array of <see cref="FlagCategory_ExceptionsRow"/> objects.</returns>
		public virtual FlagCategory_ExceptionsRow[] GetAsArray(string whereSql, string orderBySql,
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
			string sql = "SELECT * FROM [dbo].[FlagCategory_Exceptions]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FlagCategory_ExceptionsRow"/> by the primary key.
		/// </summary>
		/// <param name="pkId">The <c>pkId</c> column value.</param>
		/// <returns>An instance of <see cref="FlagCategory_ExceptionsRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FlagCategory_ExceptionsRow GetByPrimaryKey(int pkId)
		{
			string whereSql = "[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PkId", pkId);
			FlagCategory_ExceptionsRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FlagCategory_ExceptionsRow"/> object to be inserted.</param>
		public virtual void Insert(FlagCategory_ExceptionsRow value)
		{
			string sqlStr = "INSERT INTO [dbo].[FlagCategory_Exceptions] (" +
				"[Category], " +
				"[CategoryFr], " +
				"[CategoryId], " +
				"[Sequence], " +
				"[SalesOrg], " +
				"[DistributionChannel], " +
				"[CreatedOn], " +
				"[UpdatedOn], " +
                "[Locale]" +                
				") VALUES (" +
				_db.CreateSqlParameterName("Category") + ", " +
				_db.CreateSqlParameterName("CategoryFr") + ", " +
				_db.CreateSqlParameterName("CategoryId") + ", " +
				_db.CreateSqlParameterName("Sequence") + ", " +
				_db.CreateSqlParameterName("SalesOrg") + ", " +
				_db.CreateSqlParameterName("DistributionChannel") + ", " +
				_db.CreateSqlParameterName("CreatedOn") + ", " +
				_db.CreateSqlParameterName("UpdatedOn") + ", " +
                _db.CreateSqlParameterName("Locale") + ");SELECT @@IDENTITY";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "Category", value.Category);
			AddParameter(cmd, "CategoryFr", value.CategoryFr);
			AddParameter(cmd, "CategoryId", value.CategoryId);
			AddParameter(cmd, "Sequence", value.Sequence);
			AddParameter(cmd, "SalesOrg", value.SalesOrg);
			AddParameter(cmd, "DistributionChannel", value.DistributionChannel);
			AddParameter(cmd, "CreatedOn",
				value.IsCreatedOnNull ? DBNull.Value : (object)value.CreatedOn);
			AddParameter(cmd, "UpdatedOn",
				value.IsUpdatedOnNull ? DBNull.Value : (object)value.UpdatedOn);
            AddParameter(cmd, "Locale", value.Locale);
			value.PkId = Convert.ToInt32(cmd.ExecuteScalar());
		}

		/// <summary>
		/// Updates a record in the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FlagCategory_ExceptionsRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FlagCategory_ExceptionsRow value)
		{
			string sqlStr = "UPDATE [dbo].[FlagCategory_Exceptions] SET " +
				"[Category]=" + _db.CreateSqlParameterName("Category") + ", " +
				"[CategoryFr]=" + _db.CreateSqlParameterName("CategoryFr") + ", " +
				"[CategoryId]=" + _db.CreateSqlParameterName("CategoryId") + ", " +
				"[Sequence]=" + _db.CreateSqlParameterName("Sequence") + ", " +
				"[SalesOrg]=" + _db.CreateSqlParameterName("SalesOrg") + ", " +
				"[DistributionChannel]=" + _db.CreateSqlParameterName("DistributionChannel") + ", " +
				"[CreatedOn]=" + _db.CreateSqlParameterName("CreatedOn") + ", " +
				"[UpdatedOn]=" + _db.CreateSqlParameterName("UpdatedOn") + ", " +
                "[Locale]=" + _db.CreateSqlParameterName("Locale") +
				" WHERE " +
				"[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "Category", value.Category);
			AddParameter(cmd, "CategoryFr", value.CategoryFr);
			AddParameter(cmd, "CategoryId", value.CategoryId);
			AddParameter(cmd, "Sequence", value.Sequence);
			AddParameter(cmd, "SalesOrg", value.SalesOrg);
			AddParameter(cmd, "DistributionChannel", value.DistributionChannel);
			AddParameter(cmd, "CreatedOn",
				value.IsCreatedOnNull ? DBNull.Value : (object)value.CreatedOn);
			AddParameter(cmd, "UpdatedOn",
				value.IsUpdatedOnNull ? DBNull.Value : (object)value.UpdatedOn);
            AddParameter(cmd, "Locale", value.Locale);
			AddParameter(cmd, "PkId", value.PkId);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FlagCategory_Exceptions</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FlagCategory_Exceptions</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FlagCategory_ExceptionsRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FlagCategory_ExceptionsRow value)
		{
			return DeleteByPrimaryKey(value.PkId);
		}

		/// <summary>
		/// Deletes a record from the <c>FlagCategory_Exceptions</c> table using
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
		/// Deletes <c>FlagCategory_Exceptions</c> records that match the specified criteria.
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
		/// to delete <c>FlagCategory_Exceptions</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			string sql = "DELETE FROM [dbo].[FlagCategory_Exceptions]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FlagCategory_Exceptions</c> table.
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
		/// <returns>An array of <see cref="FlagCategory_ExceptionsRow"/> objects.</returns>
		protected FlagCategory_ExceptionsRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FlagCategory_ExceptionsRow"/> objects.</returns>
		protected FlagCategory_ExceptionsRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FlagCategory_ExceptionsRow"/> objects.</returns>
		protected virtual FlagCategory_ExceptionsRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int pkIdColumnIndex = reader.GetOrdinal("pkId");
			int categoryColumnIndex = reader.GetOrdinal("Category");
			int categoryFrColumnIndex = reader.GetOrdinal("CategoryFr");
			int categoryIdColumnIndex = reader.GetOrdinal("CategoryId");
			int sequenceColumnIndex = reader.GetOrdinal("Sequence");
			int salesOrgColumnIndex = reader.GetOrdinal("SalesOrg");
			int distributionChannelColumnIndex = reader.GetOrdinal("DistributionChannel");
			int createdOnColumnIndex = reader.GetOrdinal("CreatedOn");
			int updatedOnColumnIndex = reader.GetOrdinal("UpdatedOn");
            int localeColumnIndex = reader.GetOrdinal("Locale");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FlagCategory_ExceptionsRow record = new FlagCategory_ExceptionsRow();
					recordList.Add(record);

					record.PkId = Convert.ToInt32(reader.GetValue(pkIdColumnIndex));
					record.Category = Convert.ToString(reader.GetValue(categoryColumnIndex));
					if(!reader.IsDBNull(categoryFrColumnIndex))
						record.CategoryFr = Convert.ToString(reader.GetValue(categoryFrColumnIndex));
					record.CategoryId = Convert.ToString(reader.GetValue(categoryIdColumnIndex));
					record.Sequence = Convert.ToInt32(reader.GetValue(sequenceColumnIndex));
					record.SalesOrg = Convert.ToString(reader.GetValue(salesOrgColumnIndex));
					record.DistributionChannel = Convert.ToString(reader.GetValue(distributionChannelColumnIndex));
					if(!reader.IsDBNull(createdOnColumnIndex))
						record.CreatedOn = Convert.ToDateTime(reader.GetValue(createdOnColumnIndex));
					if(!reader.IsDBNull(updatedOnColumnIndex))
						record.UpdatedOn = Convert.ToDateTime(reader.GetValue(updatedOnColumnIndex));
                    if (!reader.IsDBNull(localeColumnIndex))
                        record.Locale = Convert.ToString(reader.GetValue(localeColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FlagCategory_ExceptionsRow[])(recordList.ToArray(typeof(FlagCategory_ExceptionsRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FlagCategory_ExceptionsRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FlagCategory_ExceptionsRow"/> object.</returns>
		protected virtual FlagCategory_ExceptionsRow MapRow(DataRow row)
		{
			FlagCategory_ExceptionsRow mappedObject = new FlagCategory_ExceptionsRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PkId"
			dataColumn = dataTable.Columns["PkId"];
			if(!row.IsNull(dataColumn))
				mappedObject.PkId = (int)row[dataColumn];
			// Column "Category"
			dataColumn = dataTable.Columns["Category"];
			if(!row.IsNull(dataColumn))
				mappedObject.Category = (string)row[dataColumn];
			// Column "CategoryFr"
			dataColumn = dataTable.Columns["CategoryFr"];
			if(!row.IsNull(dataColumn))
				mappedObject.CategoryFr = (string)row[dataColumn];
			// Column "CategoryId"
			dataColumn = dataTable.Columns["CategoryId"];
			if(!row.IsNull(dataColumn))
				mappedObject.CategoryId = (string)row[dataColumn];
			// Column "Sequence"
			dataColumn = dataTable.Columns["Sequence"];
			if(!row.IsNull(dataColumn))
				mappedObject.Sequence = (int)row[dataColumn];
			// Column "SalesOrg"
			dataColumn = dataTable.Columns["SalesOrg"];
			if(!row.IsNull(dataColumn))
				mappedObject.SalesOrg = (string)row[dataColumn];
			// Column "DistributionChannel"
			dataColumn = dataTable.Columns["DistributionChannel"];
			if(!row.IsNull(dataColumn))
				mappedObject.DistributionChannel = (string)row[dataColumn];
			// Column "CreatedOn"
			dataColumn = dataTable.Columns["CreatedOn"];
			if(!row.IsNull(dataColumn))
				mappedObject.CreatedOn = (System.DateTime)row[dataColumn];
			// Column "UpdatedOn"
			dataColumn = dataTable.Columns["UpdatedOn"];
			if(!row.IsNull(dataColumn))
				mappedObject.UpdatedOn = (System.DateTime)row[dataColumn];
            // Column "Locale"
            dataColumn = dataTable.Columns["Locale"];
            if (!row.IsNull(dataColumn))
                mappedObject.Locale = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FlagCategory_Exceptions";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PkId", typeof(int));
			dataColumn.Caption = "pkId";
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn.Unique = true;
			dataColumn.AutoIncrement = true;
			dataColumn = dataTable.Columns.Add("Category", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CategoryFr", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CategoryId", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Sequence", typeof(int));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SalesOrg", typeof(string));
			dataColumn.MaxLength = 4;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DistributionChannel", typeof(string));
			dataColumn.MaxLength = 2;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CreatedOn", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("UpdatedOn", typeof(System.DateTime));
            dataColumn = dataTable.Columns.Add("Locale", typeof(string));
            dataColumn.MaxLength = 2;
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

				case "Category":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CategoryFr":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CategoryId":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Sequence":
					parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

				case "SalesOrg":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DistributionChannel":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CreatedOn":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "UpdatedOn":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

                case "Locale":
                    parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FlagCategory_ExceptionsCollection_Base class
}  // End of namespace
