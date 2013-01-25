// <fileinfo name="MarketingInfo_BackupCollection_Base.cs">
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
	/// The base class for <see cref="MarketingInfo_BackupCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MarketingInfo_BackupCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MarketingInfo_BackupCollection_Base
	{
		// Constants
		public const string PkIdColumnName = "pkId";
		public const string StyleNumberColumnName = "StyleNumber";
		public const string SalesOrgColumnName = "SalesOrg";
		public const string DistributionChannelColumnName = "DistributionChannel";
		public const string MarketingDescEnColumnName = "MarketingDescEn";
		public const string MarketingDescFrColumnName = "MarketingDescFr";
		public const string StyleKeywordsColumnName = "StyleKeywords";
		public const string StyleSizeRunColumnName = "StyleSizeRun";
		public const string NavCategory1ColumnName = "NavCategory1";
		public const string NavCategory2ColumnName = "NavCategory2";
		public const string NavCategory3ColumnName = "NavCategory3";
		public const string NavCategory4ColumnName = "NavCategory4";
		public const string NavCategoryFr1ColumnName = "NavCategoryFr1";
		public const string NavCategoryFr2ColumnName = "NavCategoryFr2";
		public const string NavCategoryFr3ColumnName = "NavCategoryFr3";
		public const string NavCategoryFr4ColumnName = "NavCategoryFr4";
		public const string Flag1ColumnName = "Flag1";
		public const string Flag2ColumnName = "Flag2";
		public const string Flag3ColumnName = "Flag3";
		public const string Flag4ColumnName = "Flag4";
		public const string Flag5ColumnName = "Flag5";
		public const string Flag6ColumnName = "Flag6";
		public const string Flag7ColumnName = "Flag7";
		public const string Flag8ColumnName = "Flag8";
		public const string Flag9ColumnName = "Flag9";
		public const string Flag10ColumnName = "Flag10";
		public const string Flag11ColumnName = "Flag11";
		public const string Flag12ColumnName = "Flag12";
		public const string CreatedOnColumnName = "CreatedOn";
		public const string UpdatedOnColumnName = "UpdatedOn";
		public const string LocaleColumnName = "Locale";

		// Instance fields
		private B2BProductCatalog _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MarketingInfo_BackupCollection_Base"/> 
		/// class with the specified <see cref="B2BProductCatalog"/>.
		/// </summary>
		/// <param name="db">The <see cref="B2BProductCatalog"/> object.</param>
		public MarketingInfo_BackupCollection_Base(B2BProductCatalog db)
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
		/// Gets an array of all records from the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <returns>An array of <see cref="MarketingInfo_BackupRow"/> objects.</returns>
		public virtual MarketingInfo_BackupRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MarketingInfo_BackupRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MarketingInfo_BackupRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MarketingInfo_BackupRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MarketingInfo_BackupRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MarketingInfo_BackupRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MarketingInfo_BackupRow"/> objects.</returns>
		public MarketingInfo_BackupRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MarketingInfo_BackupRow"/> objects that 
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
		/// <returns>An array of <see cref="MarketingInfo_BackupRow"/> objects.</returns>
		public virtual MarketingInfo_BackupRow[] GetAsArray(string whereSql, string orderBySql,
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
			string sql = "SELECT * FROM [dbo].[MarketingInfo_Backup]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="MarketingInfo_BackupRow"/> by the primary key.
		/// </summary>
		/// <param name="pkId">The <c>pkId</c> column value.</param>
		/// <returns>An instance of <see cref="MarketingInfo_BackupRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual MarketingInfo_BackupRow GetByPrimaryKey(int pkId)
		{
			string whereSql = "[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PkId", pkId);
			MarketingInfo_BackupRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MarketingInfo_BackupRow"/> object to be inserted.</param>
		public virtual void Insert(MarketingInfo_BackupRow value)
		{
			string sqlStr = "INSERT INTO [dbo].[MarketingInfo_Backup] (" +
				"[StyleNumber], " +
				"[SalesOrg], " +
				"[DistributionChannel], " +
				"[MarketingDescEn], " +
				"[MarketingDescFr], " +
				"[StyleKeywords], " +
				"[StyleSizeRun], " +
				"[NavCategory1], " +
				"[NavCategory2], " +
				"[NavCategory3], " +
				"[NavCategory4], " +
				"[NavCategoryFr1], " +
				"[NavCategoryFr2], " +
				"[NavCategoryFr3], " +
				"[NavCategoryFr4], " +
				"[Flag1], " +
				"[Flag2], " +
				"[Flag3], " +
				"[Flag4], " +
				"[Flag5], " +
				"[Flag6], " +
				"[Flag7], " +
				"[Flag8], " +
				"[Flag9], " +
				"[Flag10], " +
				"[Flag11], " +
				"[Flag12], " +
				"[CreatedOn], " +
				"[UpdatedOn], " +
                "[Locale]" +                
				") VALUES (" +
				_db.CreateSqlParameterName("StyleNumber") + ", " +
				_db.CreateSqlParameterName("SalesOrg") + ", " +
				_db.CreateSqlParameterName("DistributionChannel") + ", " +
				_db.CreateSqlParameterName("MarketingDescEn") + ", " +
				_db.CreateSqlParameterName("MarketingDescFr") + ", " +
				_db.CreateSqlParameterName("StyleKeywords") + ", " +
				_db.CreateSqlParameterName("StyleSizeRun") + ", " +
				_db.CreateSqlParameterName("NavCategory1") + ", " +
				_db.CreateSqlParameterName("NavCategory2") + ", " +
				_db.CreateSqlParameterName("NavCategory3") + ", " +
				_db.CreateSqlParameterName("NavCategory4") + ", " +
				_db.CreateSqlParameterName("NavCategoryFr1") + ", " +
				_db.CreateSqlParameterName("NavCategoryFr2") + ", " +
				_db.CreateSqlParameterName("NavCategoryFr3") + ", " +
				_db.CreateSqlParameterName("NavCategoryFr4") + ", " +
				_db.CreateSqlParameterName("Flag1") + ", " +
				_db.CreateSqlParameterName("Flag2") + ", " +
				_db.CreateSqlParameterName("Flag3") + ", " +
				_db.CreateSqlParameterName("Flag4") + ", " +
				_db.CreateSqlParameterName("Flag5") + ", " +
				_db.CreateSqlParameterName("Flag6") + ", " +
				_db.CreateSqlParameterName("Flag7") + ", " +
				_db.CreateSqlParameterName("Flag8") + ", " +
				_db.CreateSqlParameterName("Flag9") + ", " +
				_db.CreateSqlParameterName("Flag10") + ", " +
				_db.CreateSqlParameterName("Flag11") + ", " +
				_db.CreateSqlParameterName("Flag12") + ", " +
				_db.CreateSqlParameterName("CreatedOn") + ", " +
				_db.CreateSqlParameterName("UpdatedOn") + ", " +
                _db.CreateSqlParameterName("Locale") + ");SELECT @@IDENTITY";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "StyleNumber", value.StyleNumber);
			AddParameter(cmd, "SalesOrg", value.SalesOrg);
			AddParameter(cmd, "DistributionChannel", value.DistributionChannel);
			AddParameter(cmd, "MarketingDescEn", value.MarketingDescEn);
			AddParameter(cmd, "MarketingDescFr", value.MarketingDescFr);
			AddParameter(cmd, "StyleKeywords", value.StyleKeywords);
			AddParameter(cmd, "StyleSizeRun", value.StyleSizeRun);
			AddParameter(cmd, "NavCategory1", value.NavCategory1);
			AddParameter(cmd, "NavCategory2", value.NavCategory2);
			AddParameter(cmd, "NavCategory3", value.NavCategory3);
			AddParameter(cmd, "NavCategory4", value.NavCategory4);
			AddParameter(cmd, "NavCategoryFr1", value.NavCategoryFr1);
			AddParameter(cmd, "NavCategoryFr2", value.NavCategoryFr2);
			AddParameter(cmd, "NavCategoryFr3", value.NavCategoryFr3);
			AddParameter(cmd, "NavCategoryFr4", value.NavCategoryFr4);
			AddParameter(cmd, "Flag1", value.Flag1);
			AddParameter(cmd, "Flag2", value.Flag2);
			AddParameter(cmd, "Flag3", value.Flag3);
			AddParameter(cmd, "Flag4", value.Flag4);
			AddParameter(cmd, "Flag5", value.Flag5);
			AddParameter(cmd, "Flag6", value.Flag6);
			AddParameter(cmd, "Flag7", value.Flag7);
			AddParameter(cmd, "Flag8", value.Flag8);
			AddParameter(cmd, "Flag9", value.Flag9);
			AddParameter(cmd, "Flag10", value.Flag10);
			AddParameter(cmd, "Flag11", value.Flag11);
			AddParameter(cmd, "Flag12", value.Flag12);
			AddParameter(cmd, "CreatedOn",
				value.IsCreatedOnNull ? DBNull.Value : (object)value.CreatedOn);
			AddParameter(cmd, "UpdatedOn",
				value.IsUpdatedOnNull ? DBNull.Value : (object)value.UpdatedOn);
            AddParameter(cmd, "Locale", value.Locale);
			value.PkId = Convert.ToInt32(cmd.ExecuteScalar());
		}

		/// <summary>
		/// Updates a record in the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MarketingInfo_BackupRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(MarketingInfo_BackupRow value)
		{
			string sqlStr = "UPDATE [dbo].[MarketingInfo_Backup] SET " +
				"[StyleNumber]=" + _db.CreateSqlParameterName("StyleNumber") + ", " +
				"[SalesOrg]=" + _db.CreateSqlParameterName("SalesOrg") + ", " +
				"[DistributionChannel]=" + _db.CreateSqlParameterName("DistributionChannel") + ", " +
				"[MarketingDescEn]=" + _db.CreateSqlParameterName("MarketingDescEn") + ", " +
				"[MarketingDescFr]=" + _db.CreateSqlParameterName("MarketingDescFr") + ", " +
				"[StyleKeywords]=" + _db.CreateSqlParameterName("StyleKeywords") + ", " +
				"[StyleSizeRun]=" + _db.CreateSqlParameterName("StyleSizeRun") + ", " +
				"[NavCategory1]=" + _db.CreateSqlParameterName("NavCategory1") + ", " +
				"[NavCategory2]=" + _db.CreateSqlParameterName("NavCategory2") + ", " +
				"[NavCategory3]=" + _db.CreateSqlParameterName("NavCategory3") + ", " +
				"[NavCategory4]=" + _db.CreateSqlParameterName("NavCategory4") + ", " +
				"[NavCategoryFr1]=" + _db.CreateSqlParameterName("NavCategoryFr1") + ", " +
				"[NavCategoryFr2]=" + _db.CreateSqlParameterName("NavCategoryFr2") + ", " +
				"[NavCategoryFr3]=" + _db.CreateSqlParameterName("NavCategoryFr3") + ", " +
				"[NavCategoryFr4]=" + _db.CreateSqlParameterName("NavCategoryFr4") + ", " +
				"[Flag1]=" + _db.CreateSqlParameterName("Flag1") + ", " +
				"[Flag2]=" + _db.CreateSqlParameterName("Flag2") + ", " +
				"[Flag3]=" + _db.CreateSqlParameterName("Flag3") + ", " +
				"[Flag4]=" + _db.CreateSqlParameterName("Flag4") + ", " +
				"[Flag5]=" + _db.CreateSqlParameterName("Flag5") + ", " +
				"[Flag6]=" + _db.CreateSqlParameterName("Flag6") + ", " +
				"[Flag7]=" + _db.CreateSqlParameterName("Flag7") + ", " +
				"[Flag8]=" + _db.CreateSqlParameterName("Flag8") + ", " +
				"[Flag9]=" + _db.CreateSqlParameterName("Flag9") + ", " +
				"[Flag10]=" + _db.CreateSqlParameterName("Flag10") + ", " +
				"[Flag11]=" + _db.CreateSqlParameterName("Flag11") + ", " +
				"[Flag12]=" + _db.CreateSqlParameterName("Flag12") + ", " +
				"[CreatedOn]=" + _db.CreateSqlParameterName("CreatedOn") + ", " +
				"[UpdatedOn]=" + _db.CreateSqlParameterName("UpdatedOn") + ", " +
                "[Locale]=" + _db.CreateSqlParameterName("Locale") +
				" WHERE " +
				"[pkId]=" + _db.CreateSqlParameterName("PkId");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "StyleNumber", value.StyleNumber);
			AddParameter(cmd, "SalesOrg", value.SalesOrg);
			AddParameter(cmd, "DistributionChannel", value.DistributionChannel);
			AddParameter(cmd, "MarketingDescEn", value.MarketingDescEn);
			AddParameter(cmd, "MarketingDescFr", value.MarketingDescFr);
			AddParameter(cmd, "StyleKeywords", value.StyleKeywords);
			AddParameter(cmd, "StyleSizeRun", value.StyleSizeRun);
			AddParameter(cmd, "NavCategory1", value.NavCategory1);
			AddParameter(cmd, "NavCategory2", value.NavCategory2);
			AddParameter(cmd, "NavCategory3", value.NavCategory3);
			AddParameter(cmd, "NavCategory4", value.NavCategory4);
			AddParameter(cmd, "NavCategoryFr1", value.NavCategoryFr1);
			AddParameter(cmd, "NavCategoryFr2", value.NavCategoryFr2);
			AddParameter(cmd, "NavCategoryFr3", value.NavCategoryFr3);
			AddParameter(cmd, "NavCategoryFr4", value.NavCategoryFr4);
			AddParameter(cmd, "Flag1", value.Flag1);
			AddParameter(cmd, "Flag2", value.Flag2);
			AddParameter(cmd, "Flag3", value.Flag3);
			AddParameter(cmd, "Flag4", value.Flag4);
			AddParameter(cmd, "Flag5", value.Flag5);
			AddParameter(cmd, "Flag6", value.Flag6);
			AddParameter(cmd, "Flag7", value.Flag7);
			AddParameter(cmd, "Flag8", value.Flag8);
			AddParameter(cmd, "Flag9", value.Flag9);
			AddParameter(cmd, "Flag10", value.Flag10);
			AddParameter(cmd, "Flag11", value.Flag11);
			AddParameter(cmd, "Flag12", value.Flag12);
			AddParameter(cmd, "CreatedOn",
				value.IsCreatedOnNull ? DBNull.Value : (object)value.CreatedOn);
			AddParameter(cmd, "UpdatedOn",
				value.IsUpdatedOnNull ? DBNull.Value : (object)value.UpdatedOn);
            AddParameter(cmd, "Locale", value.Locale);
			AddParameter(cmd, "PkId", value.PkId);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>MarketingInfo_Backup</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>MarketingInfo_Backup</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MarketingInfo_BackupRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(MarketingInfo_BackupRow value)
		{
			return DeleteByPrimaryKey(value.PkId);
		}

		/// <summary>
		/// Deletes a record from the <c>MarketingInfo_Backup</c> table using
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
		/// Deletes <c>MarketingInfo_Backup</c> records that match the specified criteria.
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
		/// to delete <c>MarketingInfo_Backup</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			string sql = "DELETE FROM [dbo].[MarketingInfo_Backup]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>MarketingInfo_Backup</c> table.
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
		/// <returns>An array of <see cref="MarketingInfo_BackupRow"/> objects.</returns>
		protected MarketingInfo_BackupRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MarketingInfo_BackupRow"/> objects.</returns>
		protected MarketingInfo_BackupRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MarketingInfo_BackupRow"/> objects.</returns>
		protected virtual MarketingInfo_BackupRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int pkIdColumnIndex = reader.GetOrdinal("pkId");
			int styleNumberColumnIndex = reader.GetOrdinal("StyleNumber");
			int salesOrgColumnIndex = reader.GetOrdinal("SalesOrg");
			int distributionChannelColumnIndex = reader.GetOrdinal("DistributionChannel");
			int marketingDescEnColumnIndex = reader.GetOrdinal("MarketingDescEn");
			int marketingDescFrColumnIndex = reader.GetOrdinal("MarketingDescFr");
			int styleKeywordsColumnIndex = reader.GetOrdinal("StyleKeywords");
			int styleSizeRunColumnIndex = reader.GetOrdinal("StyleSizeRun");
			int navCategory1ColumnIndex = reader.GetOrdinal("NavCategory1");
			int navCategory2ColumnIndex = reader.GetOrdinal("NavCategory2");
			int navCategory3ColumnIndex = reader.GetOrdinal("NavCategory3");
			int navCategory4ColumnIndex = reader.GetOrdinal("NavCategory4");
			int navCategoryFr1ColumnIndex = reader.GetOrdinal("NavCategoryFr1");
			int navCategoryFr2ColumnIndex = reader.GetOrdinal("NavCategoryFr2");
			int navCategoryFr3ColumnIndex = reader.GetOrdinal("NavCategoryFr3");
			int navCategoryFr4ColumnIndex = reader.GetOrdinal("NavCategoryFr4");
			int flag1ColumnIndex = reader.GetOrdinal("Flag1");
			int flag2ColumnIndex = reader.GetOrdinal("Flag2");
			int flag3ColumnIndex = reader.GetOrdinal("Flag3");
			int flag4ColumnIndex = reader.GetOrdinal("Flag4");
			int flag5ColumnIndex = reader.GetOrdinal("Flag5");
			int flag6ColumnIndex = reader.GetOrdinal("Flag6");
			int flag7ColumnIndex = reader.GetOrdinal("Flag7");
			int flag8ColumnIndex = reader.GetOrdinal("Flag8");
			int flag9ColumnIndex = reader.GetOrdinal("Flag9");
			int flag10ColumnIndex = reader.GetOrdinal("Flag10");
			int flag11ColumnIndex = reader.GetOrdinal("Flag11");
			int flag12ColumnIndex = reader.GetOrdinal("Flag12");
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
					MarketingInfo_BackupRow record = new MarketingInfo_BackupRow();
					recordList.Add(record);

					record.PkId = Convert.ToInt32(reader.GetValue(pkIdColumnIndex));
					record.StyleNumber = Convert.ToString(reader.GetValue(styleNumberColumnIndex));
					if(!reader.IsDBNull(salesOrgColumnIndex))
						record.SalesOrg = Convert.ToString(reader.GetValue(salesOrgColumnIndex));
					if(!reader.IsDBNull(distributionChannelColumnIndex))
						record.DistributionChannel = Convert.ToString(reader.GetValue(distributionChannelColumnIndex));
					if(!reader.IsDBNull(marketingDescEnColumnIndex))
						record.MarketingDescEn = Convert.ToString(reader.GetValue(marketingDescEnColumnIndex));
					if(!reader.IsDBNull(marketingDescFrColumnIndex))
						record.MarketingDescFr = Convert.ToString(reader.GetValue(marketingDescFrColumnIndex));
					if(!reader.IsDBNull(styleKeywordsColumnIndex))
						record.StyleKeywords = Convert.ToString(reader.GetValue(styleKeywordsColumnIndex));
					if(!reader.IsDBNull(styleSizeRunColumnIndex))
						record.StyleSizeRun = Convert.ToString(reader.GetValue(styleSizeRunColumnIndex));
					if(!reader.IsDBNull(navCategory1ColumnIndex))
						record.NavCategory1 = Convert.ToString(reader.GetValue(navCategory1ColumnIndex));
					if(!reader.IsDBNull(navCategory2ColumnIndex))
						record.NavCategory2 = Convert.ToString(reader.GetValue(navCategory2ColumnIndex));
					if(!reader.IsDBNull(navCategory3ColumnIndex))
						record.NavCategory3 = Convert.ToString(reader.GetValue(navCategory3ColumnIndex));
					if(!reader.IsDBNull(navCategory4ColumnIndex))
						record.NavCategory4 = Convert.ToString(reader.GetValue(navCategory4ColumnIndex));
					if(!reader.IsDBNull(navCategoryFr1ColumnIndex))
						record.NavCategoryFr1 = Convert.ToString(reader.GetValue(navCategoryFr1ColumnIndex));
					if(!reader.IsDBNull(navCategoryFr2ColumnIndex))
						record.NavCategoryFr2 = Convert.ToString(reader.GetValue(navCategoryFr2ColumnIndex));
					if(!reader.IsDBNull(navCategoryFr3ColumnIndex))
						record.NavCategoryFr3 = Convert.ToString(reader.GetValue(navCategoryFr3ColumnIndex));
					if(!reader.IsDBNull(navCategoryFr4ColumnIndex))
						record.NavCategoryFr4 = Convert.ToString(reader.GetValue(navCategoryFr4ColumnIndex));
					if(!reader.IsDBNull(flag1ColumnIndex))
						record.Flag1 = Convert.ToString(reader.GetValue(flag1ColumnIndex));
					if(!reader.IsDBNull(flag2ColumnIndex))
						record.Flag2 = Convert.ToString(reader.GetValue(flag2ColumnIndex));
					if(!reader.IsDBNull(flag3ColumnIndex))
						record.Flag3 = Convert.ToString(reader.GetValue(flag3ColumnIndex));
					if(!reader.IsDBNull(flag4ColumnIndex))
						record.Flag4 = Convert.ToString(reader.GetValue(flag4ColumnIndex));
					if(!reader.IsDBNull(flag5ColumnIndex))
						record.Flag5 = Convert.ToString(reader.GetValue(flag5ColumnIndex));
					if(!reader.IsDBNull(flag6ColumnIndex))
						record.Flag6 = Convert.ToString(reader.GetValue(flag6ColumnIndex));
					if(!reader.IsDBNull(flag7ColumnIndex))
						record.Flag7 = Convert.ToString(reader.GetValue(flag7ColumnIndex));
					if(!reader.IsDBNull(flag8ColumnIndex))
						record.Flag8 = Convert.ToString(reader.GetValue(flag8ColumnIndex));
					if(!reader.IsDBNull(flag9ColumnIndex))
						record.Flag9 = Convert.ToString(reader.GetValue(flag9ColumnIndex));
					if(!reader.IsDBNull(flag10ColumnIndex))
						record.Flag10 = Convert.ToString(reader.GetValue(flag10ColumnIndex));
					if(!reader.IsDBNull(flag11ColumnIndex))
						record.Flag11 = Convert.ToString(reader.GetValue(flag11ColumnIndex));
					if(!reader.IsDBNull(flag12ColumnIndex))
						record.Flag12 = Convert.ToString(reader.GetValue(flag12ColumnIndex));
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
			return (MarketingInfo_BackupRow[])(recordList.ToArray(typeof(MarketingInfo_BackupRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MarketingInfo_BackupRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MarketingInfo_BackupRow"/> object.</returns>
		protected virtual MarketingInfo_BackupRow MapRow(DataRow row)
		{
			MarketingInfo_BackupRow mappedObject = new MarketingInfo_BackupRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PkId"
			dataColumn = dataTable.Columns["PkId"];
			if(!row.IsNull(dataColumn))
				mappedObject.PkId = (int)row[dataColumn];
			// Column "StyleNumber"
			dataColumn = dataTable.Columns["StyleNumber"];
			if(!row.IsNull(dataColumn))
				mappedObject.StyleNumber = (string)row[dataColumn];
			// Column "SalesOrg"
			dataColumn = dataTable.Columns["SalesOrg"];
			if(!row.IsNull(dataColumn))
				mappedObject.SalesOrg = (string)row[dataColumn];
			// Column "DistributionChannel"
			dataColumn = dataTable.Columns["DistributionChannel"];
			if(!row.IsNull(dataColumn))
				mappedObject.DistributionChannel = (string)row[dataColumn];
			// Column "MarketingDescEn"
			dataColumn = dataTable.Columns["MarketingDescEn"];
			if(!row.IsNull(dataColumn))
				mappedObject.MarketingDescEn = (string)row[dataColumn];
			// Column "MarketingDescFr"
			dataColumn = dataTable.Columns["MarketingDescFr"];
			if(!row.IsNull(dataColumn))
				mappedObject.MarketingDescFr = (string)row[dataColumn];
			// Column "StyleKeywords"
			dataColumn = dataTable.Columns["StyleKeywords"];
			if(!row.IsNull(dataColumn))
				mappedObject.StyleKeywords = (string)row[dataColumn];
			// Column "StyleSizeRun"
			dataColumn = dataTable.Columns["StyleSizeRun"];
			if(!row.IsNull(dataColumn))
				mappedObject.StyleSizeRun = (string)row[dataColumn];
			// Column "NavCategory1"
			dataColumn = dataTable.Columns["NavCategory1"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategory1 = (string)row[dataColumn];
			// Column "NavCategory2"
			dataColumn = dataTable.Columns["NavCategory2"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategory2 = (string)row[dataColumn];
			// Column "NavCategory3"
			dataColumn = dataTable.Columns["NavCategory3"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategory3 = (string)row[dataColumn];
			// Column "NavCategory4"
			dataColumn = dataTable.Columns["NavCategory4"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategory4 = (string)row[dataColumn];
			// Column "NavCategoryFr1"
			dataColumn = dataTable.Columns["NavCategoryFr1"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategoryFr1 = (string)row[dataColumn];
			// Column "NavCategoryFr2"
			dataColumn = dataTable.Columns["NavCategoryFr2"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategoryFr2 = (string)row[dataColumn];
			// Column "NavCategoryFr3"
			dataColumn = dataTable.Columns["NavCategoryFr3"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategoryFr3 = (string)row[dataColumn];
			// Column "NavCategoryFr4"
			dataColumn = dataTable.Columns["NavCategoryFr4"];
			if(!row.IsNull(dataColumn))
				mappedObject.NavCategoryFr4 = (string)row[dataColumn];
			// Column "Flag1"
			dataColumn = dataTable.Columns["Flag1"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag1 = (string)row[dataColumn];
			// Column "Flag2"
			dataColumn = dataTable.Columns["Flag2"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag2 = (string)row[dataColumn];
			// Column "Flag3"
			dataColumn = dataTable.Columns["Flag3"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag3 = (string)row[dataColumn];
			// Column "Flag4"
			dataColumn = dataTable.Columns["Flag4"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag4 = (string)row[dataColumn];
			// Column "Flag5"
			dataColumn = dataTable.Columns["Flag5"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag5 = (string)row[dataColumn];
			// Column "Flag6"
			dataColumn = dataTable.Columns["Flag6"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag6 = (string)row[dataColumn];
			// Column "Flag7"
			dataColumn = dataTable.Columns["Flag7"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag7 = (string)row[dataColumn];
			// Column "Flag8"
			dataColumn = dataTable.Columns["Flag8"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag8 = (string)row[dataColumn];
			// Column "Flag9"
			dataColumn = dataTable.Columns["Flag9"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag9 = (string)row[dataColumn];
			// Column "Flag10"
			dataColumn = dataTable.Columns["Flag10"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag10 = (string)row[dataColumn];
			// Column "Flag11"
			dataColumn = dataTable.Columns["Flag11"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag11 = (string)row[dataColumn];
			// Column "Flag12"
			dataColumn = dataTable.Columns["Flag12"];
			if(!row.IsNull(dataColumn))
				mappedObject.Flag12 = (string)row[dataColumn];
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
		/// the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MarketingInfo_Backup";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PkId", typeof(int));
			dataColumn.Caption = "pkId";
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn.Unique = true;
			dataColumn.AutoIncrement = true;
			dataColumn = dataTable.Columns.Add("StyleNumber", typeof(string));
			dataColumn.MaxLength = 18;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SalesOrg", typeof(string));
			dataColumn.MaxLength = 4;
			dataColumn = dataTable.Columns.Add("DistributionChannel", typeof(string));
			dataColumn.MaxLength = 2;
			dataColumn = dataTable.Columns.Add("MarketingDescEn", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("MarketingDescFr", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("StyleKeywords", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("StyleSizeRun", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("NavCategory1", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategory2", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategory3", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategory4", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategoryFr1", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategoryFr2", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategoryFr3", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NavCategoryFr4", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("Flag1", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag2", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag3", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag4", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag5", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag6", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag7", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag8", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag9", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag10", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag11", typeof(string));
			dataColumn.MaxLength = 75;
			dataColumn = dataTable.Columns.Add("Flag12", typeof(string));
			dataColumn.MaxLength = 75;
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

				case "StyleNumber":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SalesOrg":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DistributionChannel":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MarketingDescEn":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MarketingDescFr":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "StyleKeywords":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "StyleSizeRun":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategory1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategory2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategory3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategory4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategoryFr1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategoryFr2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategoryFr3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NavCategoryFr4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag6":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag7":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag8":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag9":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag10":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag11":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "Flag12":
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
	} // End of MarketingInfo_BackupCollection_Base class
}  // End of namespace
