using System;

namespace B2BProductCatalog.Core.Entities
{
    public class Style_Locale
    {
        public virtual int Id { get; private set; }
        public virtual Style Style { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual string SalesOrg { get; set; }
        public virtual string DistChan { get; set; }
        public virtual string Division { get; set; }
        public virtual string DivisionDesc { get; set; }
        public virtual string Color { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? MaterialCreated { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? ActiveDate { get; set; }
        public virtual string DefaultPlant { get; set; }
        public virtual string Season { get; set; }
        public virtual string GenderId { get; set; }
        public virtual string GenderDesc { get; set; }
        public virtual int Inventory { get; set; }
        public virtual int POQuantity { get; set; }
        public virtual string UofM { get; set; }
        public virtual string BoxLabelColor { get; set; }
    }
}