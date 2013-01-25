namespace MarketingGenerator.Core.DbObjects
{
    public class MarketingInfoRow : MarketingInfoRow_Base
    {
        public MarketingInfoRow() { }

        public void Insert()
        {
            using (B2BProductCatalog database = new B2BProductCatalog())
            {
                database.MarketingInfoCollection.Insert(this);
            }
        }

        public void Save()
        {
            using (B2BProductCatalog database = new B2BProductCatalog())
            {
                database.MarketingInfoCollection.Update(this);
            }
        }
    }
}
