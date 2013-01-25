using System;
using System.Data;

namespace MarketingGenerator.Core.DbObjects
{
    public class B2BProductCatalog : B2BProductCatalog_Base
    {
        private const string ConfigDBName = "B2BProductCatalogDB";
        
        public B2BProductCatalog() { }

		/// <summary>
		/// Creates a new connection to the database.
		/// </summary>
		/// <returns>An <see cref="System.Data.IDbConnection"/> object.</returns>
		protected override IDbConnection CreateConnection()
		{
            string connString = string.Empty;

            try
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings[ConfigDBName].ConnectionString;
            }
            catch
            {
                throw new Exception("Could not load connection string.  Make sure there is a <connectionStrings> setting named " + ConfigDBName + " in the Web.config file.");
            }

            return new System.Data.SqlClient.SqlConnection(connString);
		}
		

		/// <summary>
		/// Creates a DataTable object for the specified command.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected internal DataTable CreateDataTable(IDbCommand command)
		{
			DataTable dataTable = new DataTable();

            new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
			
            return dataTable;
		}

		/// <summary>
		/// Returns a SQL statement parameter name that is specific for the data provider.
		/// For example it returns ? for OleDb provider, or @paramName for MS SQL provider.
		/// </summary>
		/// <param name="paramName">The data provider neutral SQL parameter name.</param>
		/// <returns>The SQL statement parameter name.</returns>
		protected internal override string CreateSqlParameterName(string paramName)
		{
			return "@" + paramName;
		}

		/// <summary>
		/// Creates a .Net data provider specific parameter name that is used to
		/// create a parameter object and add it to the parameter collection of
		/// <see cref="System.Data.IDbCommand"/>.
		/// </summary>
		/// <param name="baseParamName">The base name of the parameter.</param>
		/// <returns>The full data provider specific parameter name.</returns>
		protected override string CreateCollectionParameterName(string baseParamName)
		{
			return "@" + baseParamName;
		}
    }
}
