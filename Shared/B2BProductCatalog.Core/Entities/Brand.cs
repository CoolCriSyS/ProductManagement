using System.Collections.Generic;

namespace B2BProductCatalog.Core.Entities
{
    public class Brand
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string B2CBrandName { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<Brand_Locale> BrandInfos { get; set; }

        public Brand()
        {
            BrandInfos = new List<Brand_Locale>();
        }

        public Brand(int id)
        {
            Id = id;
        }
    }

    /// <summary>
    /// Corresponding BrandIds in the database
    /// </summary>
    public enum BrandEnum
    {
        Bates = 1,
        CatFootwear = 2,
        Chaco = 3,
        Cushe = 4,
        HarleyDavidson = 5,
        HushPuppies = 6,
        Hytest = 7,
        Merrell = 8,
        MerrellApparel = 9,
        Patagonia = 10,
        Sebago = 11,
        SebagoApparel = 12,
        WolverineApparel = 13,
        Wolverine = 14
    }
}
