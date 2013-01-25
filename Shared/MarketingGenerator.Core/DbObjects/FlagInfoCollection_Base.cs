// <fileinfo name="FlagInfoCollection_Base.cs">
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
	/// The base class for <see cref="FlagInfoCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FlagInfoCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FlagInfoCollection_Base
	{
		// Constants
		public const string PkIdColumnName = "pkId";
		public const string FlagIdColumnName = "FlagId";
		public const string FlagNameColumnName = "FlagName";
		public const string FlagNameFrColumnName = "FlagNameFr";
		public const string FlagDescriptionColumnName = "FlagDescription";
		public const string FlagDescriptionFrColumnName = "FlagDescriptionFr";
		public const string CategoryColumnName = "Category";
		public const string FileNameColumnName = "FileName";
		public const string SalesOrgColumnName = "SalesOrg";
		public const string DistributionChannelColumnName = "DistributionChannel";
		public const string SequenceColumnName = "Sequence";
		public const string CreatedOnColumnName = "CreatedOn";
		public const string UpdatedOnColumnName = "UpdatedOn";
		public const string LocaleColumnName = "Locale";

		// Instance fields
		private B2BProductCatalog _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FlagInfoCollection_Base"/> 
		/// class with the specified <see cref="B2BProductCatalog"/>.
		/// </summary>
		/// <param name="db">The <see cref="B2BProductCatalog"/> object.</param>
		public FlagInfoCollection_Base(B2BProductCatalog db)
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
		/// Gets an array of all records from the <c>FlagInfo</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FlagInfoRow"/> objects.</returns>
		public virtual FlagInfoRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FlagInfo</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FlagInfo</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FlagInfoRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FlagInfoRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FlagInfoRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FlagInfoRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FlagInfoRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FlagInfoRow"/> objects.</returns>
		public FlagInfoRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FlagInfoRow"/> objects that 
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
		/// <returns>An array of <see cref="FlagInfoRow"/> objects.</returns>
		public virtual FlagInfoRow[] GetAsArray(string whereSql, string orderBySql,
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
			string sql = "SELECT * FROM [dbo].[FlagInfo]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FlagInfoRow"/> by the primary key.
		/// </summary>
		/// <param name="pkId">The <c>pkId</c> column value.</param>
		/// <returns>An instance of <see cref="FlagInfoRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FlagInfoRow GetByPrimaryKey(int pkId)
		{
			string whereSql = "[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PkId", pkId);
			FlagInfoRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>FlagInfo</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FlagInfoRow"/> object to be inserted.</param>
		public virtual void Insert(FlagInfoRow value)
		{
			string sqlStr = "INSERT INTO [dbo].[FlagInfo] (" +
				"[FlagId], " +
				"[FlagName], " +
				"[FlagNameFr], " +
				"[FlagDescription], " +
				"[FlagDescriptionFr], " +
				"[Category], " +
				"[FileName], " +
				"[SalesOrg], " +
				"[DistributionChannel], " +
				"[Sequence], " +
				"[CreatedOn], " +
				"[UpdatedOn], " +
                "[Locale]" +                
				") VALUES (" +
				_db.CreateSqlParameterName("FlagId") + ", " +
				_db.CreateSqlParameterName("FlagName") + ", " +
				_db.CreateSqlParameterName("FlagNameFr") + ", " +
				_db.CreateSqlParameterName("FlagDescription") + ", " +
				_db.CreateSqlParameterName("FlagDescriptionFr") + ", " +
				_db.CreateSqlParameterName("Category") + ", " +
				_db.CreateSqlParameterName("FileName") + ", " +
				_db.CreateSqlParameterName("SalesOrg") + ", " +
				_db.CreateSqlParameterName("DistributionChannel") + ", " +
				_db.CreateSqlParameterName("Sequence") + ", " +
				_db.CreateSqlParameterName("CreatedOn") + ", " +
				_db.CreateSqlParameterName("UpdatedOn") + ", " +
                _db.CreateSqlParameterName("Locale") + ");SELECT @@IDENTITY";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FlagId", value.FlagId);
			AddParameter(cmd, "FlagName", value.FlagName);
			AddParameter(cmd, "FlagNameFr", value.FlagNameFr);
			AddParameter(cmd, "FlagDescription", value.FlagDescription);
			AddParameter(cmd, "FlagDescriptionFr", value.FlagDescriptionFr);
			AddParameter(cmd, "Category", value.Category);
			AddParameter(cmd, "FileName", value.FileName);
			AddParameter(cmd, "SalesOrg", value.SalesOrg);
			AddParameter(cmd, "DistributionChannel", value.DistributionChannel);
			AddParameter(cmd, "Sequence",
				value.IsSequenceNull ? DBNull.Value : (object)value.Sequence);
			AddParameter(cmd, "CreatedOn",
				value.IsCreatedOnNull ? DBNull.Value : (object)value.CreatedOn);
			AddParameter(cmd, "UpdatedOn",
				value.IsUpdatedOnNull ? DBNull.Value : (object)value.UpdatedOn);
            AddParameter(cmd, "Locale", value.Locale);
			value.PkId = Convert.ToInt32(cmd.ExecuteScalar());
		}

		/// <summary>
		/// Updates a record in the <c>FlagInfo</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FlagInfoRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FlagInfoRow value)
		{
			string sqlStr = "UPDATE [dbo].[FlagInfo] SET " +
				"[FlagId]=" + _db.CreateSqlParameterName("FlagId") + ", " +
				"[FlagName]=" + _db.CreateSqlParameterName("FlagName") + ", " +
				"[FlagNameFr]=" + _db.CreateSqlParameterName("FlagNameFr") + ", " +
				"[FlagDescription]=" + _db.CreateSqlParameterName("FlagDescription") + ", " +
				"[FlagDescriptionFr]=" + _db.CreateSqlParameterName("FlagDescriptionFr") + ", " +
				"[Category]=" + _db.CreateSqlParameterName("Category") + ", " +
				"[FileName]=" + _db.CreateSqlParameterName("FileName") + ", " +
				"[SalesOrg]=" + _db.CreateSqlParameterName("SalesOrg") + ", " +
				"[DistributionChannel]=" + _db.CreateSqlParameterName("DistributionChannel") + ", " +
				"[Sequence]=" + _db.CreateSqlParameterName("Sequence") + ", " +
				"[CreatedOn]=" + _db.CreateSqlParameterName("CreatedOn") + ", " +
				"[UpdatedOn]=" + _db.CreateSqlParameterName("UpdatedOn") + ", " +
                "[Locale]=" + _db.CreateSqlParameterName("Locale") +
				" WHERE " +
				"[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FlagId", value.FlagId);
			AddParameter(cmd, "FlagName", value.FlagName);
			AddParameter(cmd, "FlagNameFr", value.FlagNameFr);
			AddParameter(cmd, "FlagDescription", value.FlagDescription);
			AddParameter(cmd, "FlagDescriptionFr", value.FlagDescriptionFr);
			AddParameter(cmd, "Category", value.Category);
			AddParameter(cmd, "FileName", value.FileName);
			AddParameter(cmd, "SalesOrg", value.SalesOrg);
			AddParameter(cmd, "DistributionChannel", value.DistributionChannel);
			AddParameter(cmd, "Sequence",
				value.IsSequenceNull ? DBNull.Value : (object)value.Sequence);
			AddParameter(cmd, "CreatedOn",
				value.IsCreatedOnNull ? DBNull.Value : (object)value.CreatedOn);
			AddParameter(cmd, "UpdatedOn",
				value.IsUpdatedOnNull ? DBNull.Value : (object)value.UpdatedOn);
            AddParameter(cmd, "Locale", value.Locale);
			AddParameter(cmd, "PkId", value.PkId);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FlagInfo</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FlagInfo</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FlagInfo</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FlagInfoRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FlagInfoRow value)
		{
			return DeleteByPrimaryKey(value.PkId);
		}

		/// <summary>
		/// Deletes a record from the <c>FlagInfo</c> table using
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
		/// Deletes <c>FlagInfo</c> records that match the specified criteria.
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
		/// to delete <c>FlagInfo</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			string sql = "DELETE FROM [dbo].[FlagInfo]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FlagInfo</c> table.
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
		/// <returns>An array of <see cref="FlagInfoRow"/> objects.</returns>
		protected FlagInfoRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FlagInfoRow"/> objects.</returns>
		protected FlagInfoRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FlagInfoRow"/> objects.</returns>
		protected virtual FlagInfoRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int pkIdColumnIndex = reader.GetOrdinal("pkId");
			int flagIdColumnIndex = reader.GetOrdinal("FlagId");
			int flagNameColumnIndex = reader.GetOrdinal("FlagName");
			int flagNameFrColumnIndex = reader.GetOrdinal("FlagNameFr");
			int flagDescriptionColumnIndex = reader.GetOrdinal("FlagDescription");
			int flagDescriptionFrColumnIndex = reader.GetOrdinal("FlagDescriptionFr");
			int categoryColumnIndex = reader.GetOrdinal("Category");
			int fileNameColumnIndex = reader.GetOrdinal("FileName");
			int salesOrgColumnIndex = reader.GetOrdinal("SalesOrg");
			int distributionChannelColumnIndex = reader.GetOrdinal("DistributionChannel");
			int sequenceColumnIndex = reader.GetOrdinal("Sequence");
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
					FlagInfoRow record = new FlagInfoRow();
					recordList.Add(record);

					record.PkId = Convert.ToInt32(reader.GetValue(pkIdColumnIndex));
					if(!reader.IsDBNull(flagIdColumnIndex))
						record.FlagId = Convert.ToString(reader.GetValue(flagIdColumnIndex));
					record.FlagName = Convert.ToString(reader.GetValue(flagNameColumnIndex));
					if(!reader.IsDBNull(flagNameFrColumnIndex))
						record.FlagNameFr = Convert.ToString(reader.GetValue(flagNameFrColumnIndex));
					if(!reader.IsDBNull(flagDescriptionColumnIndex))
						record.FlagDescription = Convert.ToString(reader.GetValue(flagDescriptionColumnIndex));
					if(!reader.IsDBNull(flagDescriptionFrColumnIndex))
						record.FlagDescriptionFr = Convert.ToString(reader.GetValue(flagDescriptionFrColumnIndex));
					record.Category = Convert.ToString(reader.GetValue(categoryColumnIndex));
					if(!reader.IsDBNull(fileNameColumnIndex))
						record.FileName = Convert.ToString(reader.GetValue(fileNameColumnIndex));
					record.SalesOrg = Convert.ToString(reader.GetValue(salesOrgColumnIndex));
					record.DistributionChannel = Convert.ToString(reader.GetValue(distributionChannelColumnIndex));
					if(!reader.IsDBNull(sequenceColumnIndex))
						record.Sequence = Convert.ToInt32(reader.GetValue(sequenceColumnIndex));
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
			return (FlagInfoRow[])(recordList.ToArray(typeof(FlagInfoRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FlagInfoRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FlagInfoRow"/> object.</returns>
		protected virtual FlagInfoRow MapRow(DataRow row)
		{
			FlagInfoRow mappedObject = new FlagInfoRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PkId"
			dataColumn = dataTable.Columns["PkId"];
			if(!row.IsNull(dataColumn))
				mappedObject.PkId = (int)row[dataColumn];
			// Column "FlagId"
			dataColumn = dataTable.Columns["FlagId"];
			if(!row.IsNull(dataColumn))
				mappedObject.FlagId = (string)row[dataColumn];
			// Column "FlagName"
			dataColumn = dataTable.Columns["FlagName"];
			if(!row.IsNull(dataColumn))
				mappedObject.FlagName = (string)row[dataColumn];
			// Column "FlagNameFr"
			dataColumn = dataTable.Columns["FlagNameFr"];
			if(!row.IsNull(dataColumn))
				mappedObject.FlagNameFr = (string)row[dataColumn];
			// Column "FlagDescription"
			dataColumn = dataTable.Columns["FlagDescription"];
			if(!row.IsNull(dataColumn))
				mappedObject.FlagDescription = (string)row[dataColumn];
			// Column "FlagDescriptionFr"
			dataColumn = dataTable.Columns["FlagDescriptionFr"];
			if(!row.IsNull(dataColumn))
				mappedObject.FlagDescriptionFr = (string)row[dataColumn];
			// Column "Category"
			dataColumn = dataTable.Columns["Category"];
			if(!row.IsNull(dataColumn))
				mappedObject.Category = (string)row[dataColumn];
			// Column "FileName"
			dataColumn = dataTable.Columns["FileName"];
			if(!row.IsNull(dataColumn))
				mappedObject.FileName = (string)row[dataColumn];
			// Column "SalesOrg"
			dataColumn = dataTable.Columns["SalesOrg"];
			if(!row.IsNull(dataColumn))
				mappedObject.SalesOrg = (string)row[dataColumn];
			// Column "DistributionChannel"
			dataColumn = dataTable.Columns["DistributionChannel"];
			if(!row.IsNull(dataColumn))
				mappedObject.DistributionChannel = (string)row[dataColumn];
			// Column "Sequence"
			dataColumn = dataTable.Columns["Sequence"];
			if(!row.IsNull(dataColumn))
				mappedObject.Sequence = (int)row[dataColumn];
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
		/// the <c>FlagInfo</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FlagInfo";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PkId", typeof(int));
			dataColumn.Caption = "pkId";
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn.Unique = true;
			dataColumn.AutoIncrement = true;
			dataColumn = dataTable.Columns.Add("FlagId", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("FlagName", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FlagNameFr", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("FlagDescription", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("FlagDescriptionFr", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("Category", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FileName", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SalesOrg", typeof(string));
			dataColumn.MaxLength = 4;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DistributionChannel", typeof(string));
			dataColumn.MaxLength = 2;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Sequence", typeof(int));
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

				case "FlagId":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FlagName":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FlagNameFr":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FlagDescription":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FlagDescriptionFr":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Category":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FileName":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SalesOrg":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DistributionChannel":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Sequence":
					parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
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
	} // End of FlagInfoCollection_Base class
}  // End of namespace
