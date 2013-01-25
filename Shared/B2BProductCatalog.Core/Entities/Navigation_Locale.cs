namespace B2BProductCatalog.Core.Entities
{
    public class Navigation_Locale
    {
        public virtual int Id { get; private set; }
        public virtual Navigation Navigation { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual string Category1 { get; set; }
        public virtual string Category2 { get; set; }
        public virtual string Category3 { get; set; }
        public virtual string Category4 { get; set; }
    }
}