using System;

namespace B2BProductCatalog.Core.Entities
{
    public class Pattern_Locale
    {
        public virtual int Id { get; private set; }
        public virtual Pattern Pattern { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual string Name { get; set; }
        public virtual string MarketingDescription { get; set; }
        public virtual string Keywords { get; set; }
        public virtual string SAPPatternId { get; set; }
        public virtual string PatternLabel1 { get; set; }
        public virtual string PatternLabel2 { get; set; }
    }
}
