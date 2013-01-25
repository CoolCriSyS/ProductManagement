using System;

namespace B2BProductCatalog.Core.Entities
{
    /// <summary>
    /// The nightly extract of SAP info.
    /// </summary>
    public class B2BExtract
    {
        public virtual int Id { get; private set; }
        public virtual string StockNumber { get; set; }
        /// <summary>
        /// This seems to be unique for every different style.
        /// </summary>
        public virtual string StyleName { get; set; }
        public virtual DateTime MaterialCreated { get; set; }
        public virtual string SalesOrganization { get; set; }
        public virtual string DistributionChannel { get; set; }
        public virtual string Division { get; set; }
        public virtual string DivisionDesc { get; set; }
        public virtual string FullHierarchy { get; set; }
        public virtual string Hierarchy1 { get; set; }
        public virtual string Hierarchy1Desc { get; set; }
        public virtual string Hierarchy2 { get; set; }
        public virtual string Hierarchy2Desc { get; set; }
        public virtual string Hierarchy3 { get; set; }
        public virtual string Hierarchy3Desc { get; set; }
        public virtual string Hierarchy4 { get; set; }
        public virtual string Hierarchy4Desc { get; set; }
        public virtual string Status { get; set; }
        public virtual string UofM { get; set; }
        public virtual string DefaultPlant { get; set; }
        public virtual string Season { get; set; }
        public virtual string PatternId { get; set; }
        public virtual string PatternLabel1 { get; set; }
        public virtual string PatternLabel2 { get; set; }
        public virtual string BoxLabelColor { get; set; }
        public virtual string GenderId { get; set; }
        public virtual string GenderDesc { get; set; }
        public virtual string GenderDescFr { get; set; }
        public virtual string CollectionId { get; set; }
        public virtual string CollectionDesc { get; set; }
        public virtual string PatternName { get; set; }
        public virtual string PatternDesc { get; set; }
        protected internal virtual string StringInventory { get; set; }
        protected internal virtual string StringPOQuantity { get; set; }
        public virtual int Inventory
        {
            get
            {
                int inventory;
                int.TryParse(StringInventory, out inventory);
                return inventory;
            }

            set { StringInventory = value.ToString(); }
        }
        public virtual int POQuantity
        {
            get
            {
                int quantity;
                int.TryParse(StringPOQuantity, out quantity);
                return quantity;
            }

            set { StringPOQuantity = value.ToString(); }
        }
        public virtual string Color { get; set; }
        public virtual string ColorFr { get; set; }

        public virtual string BrandName
        {
            get
            {
                if (StockNumber.StartsWith("W"))
                    return "Wolverine";
                if (StockNumber.StartsWith("E"))
                    return "Bates";
                if (StockNumber.StartsWith("D"))
                    return "Harley-Davidson";
                if (StockNumber.StartsWith("P"))
                    return "CAT";

                return "Hy-Test";
            }
        }
    }
}