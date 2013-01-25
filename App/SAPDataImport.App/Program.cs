using System.Linq;
using B2BProductCatalog.Core;

namespace SAPDataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = string.Empty;
            
            if (args.Any(arg => arg.StartsWith("-path=")))
                filePath = args.FirstOrDefault(arg => arg.StartsWith("-path")).Split('=')[1];

            //if (!string.IsNullOrEmpty(filePath))
            //{
            //    NHibernateSessionFactory.Session.CreateSQLQuery("exec BulkInsertIntoB2BExtract ('" + filePath + "')");
            //    NHibernateSessionFactory.Session.Transaction.Begin();
            //    NHibernateSessionFactory.Session.Transaction.Commit();
            //}

            //TODO: Once the data dump is complete, compare against what is already in the db and generate emails to
            // notify users what new product was added and to login to update it
        }
    }
}
