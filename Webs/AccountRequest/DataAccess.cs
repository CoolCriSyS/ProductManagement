using System;
using System.Data;

namespace AccountRequest
{
    public class DataAccess
    {
        private const string ConfigDbName = "AccountRequestDB";
        private readonly string _connString;

        public DataAccess()
        {
            _connString = System.Configuration.ConfigurationManager.ConnectionStrings[ConfigDbName].ConnectionString;
        }

        public int InsertRequest(string companyName, string customerNumber, string firstName, string lastName,
            string email, string phone, string title, DateTime timestamp, string locale)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connString);
            connection.Open();

            using (IDbTransaction transaction = connection.BeginTransaction())
            {
                const string sqlStr = "INSERT INTO [dbo].[Requests] ([CompanyName], [CustomerNumber], [FirstName], " +
                                      "[LastName], [Email], [Phone], [Title], [Timestamp], [Locale]) VALUES " +
                                      "(@CompanyName, @CustomerNumber, @FirstName, @LastName, @Email, @Phone, @Title, @Timestamp, @Locale);" +
                                      "SELECT @@IDENTITY";
                
                IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = sqlStr;
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = "CompanyName";
                parameter.DbType = DbType.String;
                parameter.Value = companyName;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "CustomerNumber";
                parameter.DbType = DbType.String;
                parameter.Value = customerNumber;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "FirstName";
                parameter.DbType = DbType.String;
                parameter.Value = firstName;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "LastName";
                parameter.DbType = DbType.String;
                parameter.Value = lastName;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "Email";
                parameter.DbType = DbType.String;
                parameter.Value = email;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "Phone";
                parameter.DbType = DbType.String;
                parameter.Value = phone;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "Title";
                parameter.DbType = DbType.String;
                parameter.Value = title;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "Timestamp";
                parameter.DbType = DbType.DateTime;
                parameter.Value = timestamp;
                cmd.Parameters.Add(parameter);
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "Locale";
                parameter.DbType = DbType.String;
                parameter.Value = locale;
                cmd.Parameters.Add(parameter);
                transaction.Commit();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
