namespace B2BProductCatalog.Core.Entities
{
    public class Brand_Locale
    {
        public virtual int Id { get; private set; }
        public virtual Brand Brand { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual string SalesOrganization { get; set; }
        public virtual string DistributionChannel { get; set; }
    }
}
