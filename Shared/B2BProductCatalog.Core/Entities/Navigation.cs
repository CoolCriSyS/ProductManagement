using System.Collections.Generic;

namespace B2BProductCatalog.Core.Entities
{
    public class Navigation
    {
        public virtual int Id { get; private set; }
        public virtual Brand Brand { get; set; }
        public virtual Pattern Pattern { get; set; }
        public virtual Style Style { get; set; }
        public virtual IList<Navigation_Locale> NavigationInfos { get; set; }

        public Navigation()
        {
            NavigationInfos = new List<Navigation_Locale>();
        }
    }
}