using System;
using System.Collections.Generic;

namespace B2BProductCatalog.Core.Entities
{
    public class Flag
    {
        public virtual int Id { get; private set; }
        public virtual Brand Brand { get; set; }
        public virtual FlagCategory FlagCategory { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual IList<Flag_Locale> FlagInfos { get; set; }

        public Flag()
        {
            FlagInfos = new List<Flag_Locale>();
        }
    }
}
