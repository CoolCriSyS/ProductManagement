using System;
using System.Collections.Generic;

namespace B2BProductCatalog.Core.Entities
{
    public class FlagCategory
    {
        public virtual int Id { get; private set; }
        public virtual Brand Brand { get; set; }
        public virtual IList<FlagCategory_Locale> FlagCategoryInfos { get; set; }

        public FlagCategory()
        {
            FlagCategoryInfos = new List<FlagCategory_Locale>();
        }
    }
}
