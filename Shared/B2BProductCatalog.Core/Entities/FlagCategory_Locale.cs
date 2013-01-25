namespace B2BProductCatalog.Core.Entities
{
    public class FlagCategory_Locale
    {
        public virtual int Id { get; private set; }
        public virtual FlagCategory FlagCategory { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual string Name { get; set; }
        public virtual int Sequence { get; set; }
    }
}
