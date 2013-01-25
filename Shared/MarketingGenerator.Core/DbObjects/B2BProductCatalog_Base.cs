// <fileinfo name="B2BProductCatalog_Base.cs">
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
	/// The base class for the <see cref="B2BProductCatalog"/> class that 
	/// represents a connection to the <c>B2BProductCatalog</c> database. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Modify the B2BProductCatalog class
	/// if you need to add or change some functionality.
	/// </remarks>
	public abstract class B2BProductCatalog_Base : IDisposable
	{
		private IDbConnection _connection;
		private IDbTransaction _transaction;

		// Table and view fields
		private B2CProductDataCollection _b2CProductData;
		private BrandCollection _brand;
		private FlagCategoryCollection _flagCategory;
		private FlagCategory_BackupCollection _flagCategory_Backup;
		private FlagCategory_ExceptionsCollection _flagCategory_Exceptions;
		private FlagInfoCollection _flagInfo;
		private FlagInfo_BackupCollection _flagInfo_Backup;
		private FlagInfo_ExceptionsCollection _flagInfo_Exceptions;
		private ImageDataCollection _imageData;
		private MarketingInfoCollection _marketingInfo;
		private MarketingInfo_BackupCollection _marketingInfo_Backup;
		private MarketingInfo_ExceptionsCollection _marketingInfo_Exceptions;
	    private SAPFileCheckCollection _sapFileCheck;

		/// <summary>
		/// Initializes a new instance of the <see cref="B2BProductCatalog_Base"/> 
		/// class and opens the database connection.
		/// </summary>
		protected B2BProductCatalog_Base() : this(true)
		{
			// EMPTY
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="B2BProductCatalog_Base"/> class.
		/// </summary>
		/// <param name="init">Specifies whether the constructor calls the
		/// <see cref="InitConnection"/> method to initialize the database connection.</param>
		protected B2BProductCatalog_Base(bool init)
		{
			if(init)
				InitConnection();
		}

		/// <summary>
		/// Initializes the database connection.
		/// </summary>
		protected void InitConnection()
		{
			_connection = CreateConnection();
			_connection.Open();
		}

		/// <summary>
		/// Creates a new connection to the database.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbConnection"/> object.</returns>
		protected abstract IDbConnection CreateConnection();

		/// <summary>
		/// Returns a SQL statement parameter name that is specific for the data provider.
		/// For example it returns ? for OleDb provider, or @paramName for MS SQL provider.
		/// </summary>
		/// <param name="paramName">The data provider neutral SQL parameter name.</param>
		/// <returns>The SQL statement parameter name.</returns>
		protected internal abstract string CreateSqlParameterName(string paramName);

		/// <summary>
		/// Creates <see cref="System.Data.IDataReader"/> for the specified DB command.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>A reference to the <see cref="System.Data.IDataReader"/> object.</returns>
		protected internal virtual IDataReader ExecuteReader(IDbCommand command)
		{
			return command.ExecuteReader();
		}

		/// <summary>
		/// Adds a new parameter to the specified command. It is not recommended that 
		/// you use this method directly from your custom code. Instead use the 
		/// <c>AddParameter</c> method of the &lt;TableCodeName&gt;Collection_Base classes.
		/// </summary>
		/// <param name="cmd">The <see cref="System.Data.IDbCommand"/> object to add the parameter to.</param>
		/// <param name="paramName">The name of the parameter.</param>
		/// <param name="dbType">One of the <see cref="System.Data.DbType"/> values. </param>
		/// <param name="value">The value of the parameter.</param>
		/// <returns>A reference to the added parameter.</returns>
		internal IDbDataParameter AddParameter(IDbCommand cmd, string paramName,
												DbType dbType, object value)
		{
			IDbDataParameter parameter = cmd.CreateParameter();
			parameter.ParameterName = CreateCollectionParameterName(paramName);
			parameter.DbType = dbType;
			parameter.Value = null == value ? DBNull.Value : value;
			cmd.Parameters.Add(parameter);
			return parameter;
		}
		
		/// <summary>
		/// Creates a .Net data provider specific name that is used by the 
		/// <see cref="AddParameter"/> method.
		/// </summary>
		/// <param name="baseParamName">The base name of the parameter.</param>
		/// <returns>The full data provider specific parameter name.</returns>
		protected abstract string CreateCollectionParameterName(string baseParamName);

		/// <summary>
		/// Gets <see cref="System.Data.IDbConnection"/> associated with this object.
		/// </summary>
		/// <value>A reference to the <see cref="System.Data.IDbConnection"/> object.</value>
		public IDbConnection Connection
		{
			get { return _connection; }
		}

		/// <summary>
		/// Gets an object that represents the <c>B2CProductData</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="B2CProductDataCollection"/> object.</value>
		public B2CProductDataCollection B2CProductDataCollection
		{
			get
			{
				if(null == _b2CProductData)
					_b2CProductData = new B2CProductDataCollection((B2BProductCatalog)this);
				return _b2CProductData;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>Brand</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="BrandCollection"/> object.</value>
		public BrandCollection BrandCollection
		{
			get
			{
				if(null == _brand)
					_brand = new BrandCollection((B2BProductCatalog)this);
				return _brand;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>FlagCategory</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="FlagCategoryCollection"/> object.</value>
		public FlagCategoryCollection FlagCategoryCollection
		{
			get
			{
				if(null == _flagCategory)
					_flagCategory = new FlagCategoryCollection((B2BProductCatalog)this);
				return _flagCategory;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>FlagCategory_Backup</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="FlagCategory_BackupCollection"/> object.</value>
		public FlagCategory_BackupCollection FlagCategory_BackupCollection
		{
			get
			{
				if(null == _flagCategory_Backup)
					_flagCategory_Backup = new FlagCategory_BackupCollection((B2BProductCatalog)this);
				return _flagCategory_Backup;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>FlagCategory_Exceptions</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="FlagCategory_ExceptionsCollection"/> object.</value>
		public FlagCategory_ExceptionsCollection FlagCategory_ExceptionsCollection
		{
			get
			{
				if(null == _flagCategory_Exceptions)
					_flagCategory_Exceptions = new FlagCategory_ExceptionsCollection((B2BProductCatalog)this);
				return _flagCategory_Exceptions;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>FlagInfo</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="FlagInfoCollection"/> object.</value>
		public FlagInfoCollection FlagInfoCollection
		{
			get
			{
				if(null == _flagInfo)
					_flagInfo = new FlagInfoCollection((B2BProductCatalog)this);
				return _flagInfo;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>FlagInfo_Backup</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="FlagInfo_BackupCollection"/> object.</value>
		public FlagInfo_BackupCollection FlagInfo_BackupCollection
		{
			get
			{
				if(null == _flagInfo_Backup)
					_flagInfo_Backup = new FlagInfo_BackupCollection((B2BProductCatalog)this);
				return _flagInfo_Backup;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>FlagInfo_Exceptions</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="FlagInfo_ExceptionsCollection"/> object.</value>
		public FlagInfo_ExceptionsCollection FlagInfo_ExceptionsCollection
		{
			get
			{
				if(null == _flagInfo_Exceptions)
					_flagInfo_Exceptions = new FlagInfo_ExceptionsCollection((B2BProductCatalog)this);
				return _flagInfo_Exceptions;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>ImageData</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="ImageDataCollection"/> object.</value>
		public ImageDataCollection ImageDataCollection
		{
			get
			{
				if(null == _imageData)
					_imageData = new ImageDataCollection((B2BProductCatalog)this);
				return _imageData;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>MarketingInfo</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="MarketingInfoCollection"/> object.</value>
		public MarketingInfoCollection MarketingInfoCollection
		{
			get
			{
				if(null == _marketingInfo)
					_marketingInfo = new MarketingInfoCollection((B2BProductCatalog)this);
				return _marketingInfo;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>MarketingInfo_Backup</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="MarketingInfo_BackupCollection"/> object.</value>
		public MarketingInfo_BackupCollection MarketingInfo_BackupCollection
		{
			get
			{
				if(null == _marketingInfo_Backup)
					_marketingInfo_Backup = new MarketingInfo_BackupCollection((B2BProductCatalog)this);
				return _marketingInfo_Backup;
			}
		}

		/// <summary>
		/// Gets an object that represents the <c>MarketingInfo_Exceptions</c> table.
		/// </summary>
		/// <value>A reference to the <see cref="MarketingInfo_ExceptionsCollection"/> object.</value>
		public MarketingInfo_ExceptionsCollection MarketingInfo_ExceptionsCollection
		{
			get
			{
				if(null == _marketingInfo_Exceptions)
					_marketingInfo_Exceptions = new MarketingInfo_ExceptionsCollection((B2BProductCatalog)this);
				return _marketingInfo_Exceptions;
			}
		}

        /// <summary>
        /// Gets an object that represents the <c>SAPFileCheck</c> table.
        /// </summary>
        /// <value>A reference to the <see cref="MarketingInfoCollection"/> object.</value>
        public SAPFileCheckCollection SAPFileCheckCollection
        {
            get
            {
                if (null == _sapFileCheck)
                    _sapFileCheck = new SAPFileCheckCollection((B2BProductCatalog)this);
                return _sapFileCheck;
            }
        }

		/// <summary>
		/// Begins a new database transaction.
		/// </summary>
		/// <seealso cref="CommitTransaction"/>
		/// <seealso cref="RollbackTransaction"/>
		/// <returns>An object representing the new transaction.</returns>
		public IDbTransaction BeginTransaction()
		{
			CheckTransactionState(false);
			_transaction = _connection.BeginTransaction();
			return _transaction;
		}

		/// <summary>
		/// Begins a new database transaction with the specified 
		/// transaction isolation level.
		/// <seealso cref="CommitTransaction"/>
		/// <seealso cref="RollbackTransaction"/>
		/// </summary>
		/// <param name="isolationLevel">The transaction isolation level.</param>
		/// <returns>An object representing the new transaction.</returns>
		public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
		{
			CheckTransactionState(false);
			_transaction = _connection.BeginTransaction(isolationLevel);
			return _transaction;
		}

		/// <summary>
		/// Commits the current database transaction.
		/// <seealso cref="BeginTransaction"/>
		/// <seealso cref="RollbackTransaction"/>
		/// </summary>
		public void CommitTransaction()
		{
			CheckTransactionState(true);
			_transaction.Commit();
			_transaction = null;
		}

		/// <summary>
		/// Rolls back the current transaction from a pending state.
		/// <seealso cref="BeginTransaction"/>
		/// <seealso cref="CommitTransaction"/>
		/// </summary>
		public void RollbackTransaction()
		{
			CheckTransactionState(true);
			_transaction.Rollback();
			_transaction = null;
		}

		// Checks the state of the current transaction
		private void CheckTransactionState(bool mustBeOpen)
		{
			if(mustBeOpen)
			{
				if(null == _transaction)
					throw new InvalidOperationException("Transaction is not open.");
			}
			else
			{
				if(null != _transaction)
					throw new InvalidOperationException("Transaction is already open.");
			}
		}

		/// <summary>
		/// Creates and returns a new <see cref="System.Data.IDbCommand"/> object.
		/// </summary>
		/// <param name="sqlText">The text of the query.</param>
		/// <returns>An <see cref="System.Data.IDbCommand"/> object.</returns>
		internal IDbCommand CreateCommand(string sqlText)
		{
			return CreateCommand(sqlText, false);
		}

		/// <summary>
		/// Creates and returns a new <see cref="System.Data.IDbCommand"/> object.
		/// </summary>
		/// <param name="sqlText">The text of the query.</param>
		/// <param name="procedure">Specifies whether the sqlText parameter is 
		/// the name of a stored procedure.</param>
		/// <returns>An <see cref="System.Data.IDbCommand"/> object.</returns>
		internal IDbCommand CreateCommand(string sqlText, bool procedure)
		{
			IDbCommand cmd = _connection.CreateCommand();
			cmd.CommandText = sqlText;
			cmd.Transaction = _transaction;
			if(procedure)
				cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		/// <summary>
		/// Rolls back any pending transactions and closes the DB connection.
		/// An application can call the <c>Close</c> method more than
		/// one time without generating an exception.
		/// </summary>
		public virtual void Close()
		{
			if(null != _connection)
				_connection.Close();
		}

		/// <summary>
		/// Rolls back any pending transactions and closes the DB connection.
		/// </summary>
		public virtual void Dispose()
		{
			Close();
			if(null != _connection)
				_connection.Dispose();
		}
	} // End of B2BProductCatalog_Base class
} // End of namespace
