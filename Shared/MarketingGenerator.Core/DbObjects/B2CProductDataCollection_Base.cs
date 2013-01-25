// <fileinfo name="B2CProductDataCollection_Base.cs">
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
	/// The base class for <see cref="B2CProductDataCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="B2CProductDataCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class B2CProductDataCollection_Base
	{
		// Constants
		public const string PkIDColumnName = "PkID";
		public const string StyleNumberColumnName = "StyleNumber";
		public const string ProductNameColumnName = "ProductName";
		public const string BrandNameColumnName = "BrandName";
		public const string ProductDescEnColumnName = "ProductDescEn";
		public const string ProductDescFrColumnName = "ProductDescFr";

		// Instance fields
		private B2BProductCatalog _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="B2CProductDataCollection_Base"/> 
		/// class with the specified <see cref="B2BProductCatalog"/>.
		/// </summary>
		/// <param name="db">The <see cref="B2BProductCatalog"/> object.</param>
		public B2CProductDataCollection_Base(B2BProductCatalog db)
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
		/// Gets an array of all records from the <c>B2CProductData</c> table.
		/// </summary>
		/// <returns>An array of <see cref="B2CProductDataRow"/> objects.</returns>
		public virtual B2CProductDataRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>B2CProductData</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>B2CProductData</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="B2CProductDataRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="B2CProductDataRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public B2CProductDataRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			B2CProductDataRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="B2CProductDataRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="B2CProductDataRow"/> objects.</returns>
		public B2CProductDataRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="B2CProductDataRow"/> objects that 
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
		/// <returns>An array of <see cref="B2CProductDataRow"/> objects.</returns>
		public virtual B2CProductDataRow[] GetAsArray(string whereSql, string orderBySql,
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
			string sql = "SELECT * FROM [dbo].[B2CProductData]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="B2CProductDataRow"/> by the primary key.
		/// </summary>
		/// <param name="pkID">The <c>PkID</c> column value.</param>
		/// <returns>An instance of <see cref="B2CProductDataRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual B2CProductDataRow GetByPrimaryKey(int pkID)
		{
			string whereSql = "[PkID]=" + _db.CreateSqlParameterName("PkID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PkID", pkID);
			B2CProductDataRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>B2CProductData</c> table.
		/// </summary>
		/// <param name="value">The <see cref="B2CProductDataRow"/> object to be inserted.</param>
		public virtual void Insert(B2CProductDataRow value)
		{
			string sqlStr = "INSERT INTO [dbo].[B2CProductData] (" +
				"[StyleNumber], " +
				"[ProductName], " +
				"[BrandName], " +
				"[ProductDescEn], " +
				"[ProductDescFr]" +
				") VALUES (" +
				_db.CreateSqlParameterName("StyleNumber") + ", " +
				_db.CreateSqlParameterName("ProductName") + ", " +
				_db.CreateSqlParameterName("BrandName") + ", " +
				_db.CreateSqlParameterName("ProductDescEn") + ", " +
				_db.CreateSqlParameterName("ProductDescFr") + ");SELECT @@IDENTITY";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "StyleNumber", value.StyleNumber);
			AddParameter(cmd, "ProductName", value.ProductName);
			AddParameter(cmd, "BrandName", value.BrandName);
			AddParameter(cmd, "ProductDescEn", value.ProductDescEn);
			AddParameter(cmd, "ProductDescFr", value.ProductDescFr);
			value.PkID = Convert.ToInt32(cmd.ExecuteScalar());
		}

		/// <summary>
		/// Updates a record in the <c>B2CProductData</c> table.
		/// </summary>
		/// <param name="value">The <see cref="B2CProductDataRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(B2CProductDataRow value)
		{
			string sqlStr = "UPDATE [dbo].[B2CProductData] SET " +
				"[StyleNumber]=" + _db.CreateSqlParameterName("StyleNumber") + ", " +
				"[ProductName]=" + _db.CreateSqlParameterName("ProductName") + ", " +
				"[BrandName]=" + _db.CreateSqlParameterName("BrandName") + ", " +
				"[ProductDescEn]=" + _db.CreateSqlParameterName("ProductDescEn") + ", " +
				"[ProductDescFr]=" + _db.CreateSqlParameterName("ProductDescFr") +
				" WHERE " +
				"[PkID]=" + _db.CreateSqlParameterName("PkID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "StyleNumber", value.StyleNumber);
			AddParameter(cmd, "ProductName", value.ProductName);
			AddParameter(cmd, "BrandName", value.BrandName);
			AddParameter(cmd, "ProductDescEn", value.ProductDescEn);
			AddParameter(cmd, "ProductDescFr", value.ProductDescFr);
			AddParameter(cmd, "PkID", value.PkID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>B2CProductData</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>B2CProductData</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
							DeleteByPrimaryKey((int)row["PkID"]);
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
		/// Deletes the specified object from the <c>B2CProductData</c> table.
		/// </summary>
		/// <param name="value">The <see cref="B2CProductDataRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(B2CProductDataRow value)
		{
			return DeleteByPrimaryKey(value.PkID);
		}

		/// <summary>
		/// Deletes a record from the <c>B2CProductData</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="pkID">The <c>PkID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(int pkID)
		{
			string whereSql = "[PkID]=" + _db.CreateSqlParameterName("PkID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PkID", pkID);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes <c>B2CProductData</c> records that match the specified criteria.
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
		/// to delete <c>B2CProductData</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			string sql = "DELETE FROM [dbo].[B2CProductData]";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>B2CProductData</c> table.
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
		/// <returns>An array of <see cref="B2CProductDataRow"/> objects.</returns>
		protected B2CProductDataRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="B2CProductDataRow"/> objects.</returns>
		protected B2CProductDataRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="B2CProductDataRow"/> objects.</returns>
		protected virtual B2CProductDataRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int pkIDColumnIndex = reader.GetOrdinal("PkID");
			int styleNumberColumnIndex = reader.GetOrdinal("StyleNumber");
			int productNameColumnIndex = reader.GetOrdinal("ProductName");
			int brandNameColumnIndex = reader.GetOrdinal("BrandName");
			int productDescEnColumnIndex = reader.GetOrdinal("ProductDescEn");
			int productDescFrColumnIndex = reader.GetOrdinal("ProductDescFr");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					B2CProductDataRow record = new B2CProductDataRow();
					recordList.Add(record);

					record.PkID = Convert.ToInt32(reader.GetValue(pkIDColumnIndex));
					record.StyleNumber = Convert.ToString(reader.GetValue(styleNumberColumnIndex));
					if(!reader.IsDBNull(productNameColumnIndex))
						record.ProductName = Convert.ToString(reader.GetValue(productNameColumnIndex));
					if(!reader.IsDBNull(brandNameColumnIndex))
						record.BrandName = Convert.ToString(reader.GetValue(brandNameColumnIndex));
					if(!reader.IsDBNull(productDescEnColumnIndex))
						record.ProductDescEn = Convert.ToString(reader.GetValue(productDescEnColumnIndex));
					if(!reader.IsDBNull(productDescFrColumnIndex))
						record.ProductDescFr = Convert.ToString(reader.GetValue(productDescFrColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (B2CProductDataRow[])(recordList.ToArray(typeof(B2CProductDataRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="B2CProductDataRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="B2CProductDataRow"/> object.</returns>
		protected virtual B2CProductDataRow MapRow(DataRow row)
		{
			B2CProductDataRow mappedObject = new B2CProductDataRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PkID"
			dataColumn = dataTable.Columns["PkID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PkID = (int)row[dataColumn];
			// Column "StyleNumber"
			dataColumn = dataTable.Columns["StyleNumber"];
			if(!row.IsNull(dataColumn))
				mappedObject.StyleNumber = (string)row[dataColumn];
			// Column "ProductName"
			dataColumn = dataTable.Columns["ProductName"];
			if(!row.IsNull(dataColumn))
				mappedObject.ProductName = (string)row[dataColumn];
			// Column "BrandName"
			dataColumn = dataTable.Columns["BrandName"];
			if(!row.IsNull(dataColumn))
				mappedObject.BrandName = (string)row[dataColumn];
			// Column "ProductDescEn"
			dataColumn = dataTable.Columns["ProductDescEn"];
			if(!row.IsNull(dataColumn))
				mappedObject.ProductDescEn = (string)row[dataColumn];
			// Column "ProductDescFr"
			dataColumn = dataTable.Columns["ProductDescFr"];
			if(!row.IsNull(dataColumn))
				mappedObject.ProductDescFr = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>B2CProductData</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "B2CProductData";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PkID", typeof(int));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn.Unique = true;
			dataColumn.AutoIncrement = true;
			dataColumn = dataTable.Columns.Add("StyleNumber", typeof(string));
			dataColumn.MaxLength = 18;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProductName", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("BrandName", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("ProductDescEn", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("ProductDescFr", typeof(string));
			dataColumn.MaxLength = 4000;
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
				case "PkID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Int32, value);
					break;

				case "StyleNumber":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ProductName":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "BrandName":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "ProductDescEn":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "ProductDescFr":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of B2CProductDataCollection_Base class
}  // End of namespace
