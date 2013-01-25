namespace B2BProductCatalog.Core.Entities
{
    public class Flag_Locale
    {
        public virtual int Id { get; private set; }
        public virtual Flag Flag { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Sequence { get; set; }
    }
}
