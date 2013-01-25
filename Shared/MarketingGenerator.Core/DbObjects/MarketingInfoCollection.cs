using System.Data;

namespace MarketingGenerator.Core.DbObjects
{
    public class MarketingInfoCollection : MarketingInfoCollection_Base
    {
        /// <summary>
		/// Initializes a new instance of the <see cref="MarketingInfoCollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal MarketingInfoCollection(B2BProductCatalog db) : base(db) { }

        //public MarketingInfoRow GetByStyleNumber(string styleNumber)
        //{
        //    string whereSql = "[StyleNumber]=" + Database.CreateSqlParameterName("StyleNumber");
        //    IDbCommand cmd = CreateGetCommand(whereSql, null);
        //    AddParameter(cmd, "StyleNumber", styleNumber);
        //    MarketingInfoRow[] tempArray = MapRecords(cmd);
        //    return 0 == tempArray.Length ? null : tempArray[0];
        //}

        public MarketingInfoRow GetByStyleNumberSOandDC(string styleNumber, string SO, string DC, string locale)
        {
            string whereSql = 
                string.Format("[StyleNumber]={0} AND SalesOrg={1} AND DistributionChannel={2} AND Locale={3}",
                    Database.CreateSqlParameterName("StyleNumber"),
                    Database.CreateSqlParameterName("SalesOrg"),
                    Database.CreateSqlParameterName("DistributionChannel"),
                    Database.CreateSqlParameterName("Locale"));
                
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "StyleNumber", styleNumber);
            AddParameter(cmd, "SalesOrg", SO);
            AddParameter(cmd, "DistributionChannel", DC);
            AddParameter(cmd, "Locale", locale);
            MarketingInfoRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }

        public DataTable GetAllByLocale(string locale)
        {
            return GetAsDataTable("Locale='" + locale + "'", "");
        }
    }
}
