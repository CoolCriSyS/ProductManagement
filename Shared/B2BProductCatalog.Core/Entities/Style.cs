using System.Collections.Generic;

namespace B2BProductCatalog.Core.Entities
{
    public class Style
    {
        public virtual int Id { get; private set; }
        public virtual Pattern Pattern { get; set; }
        public virtual string StyleNumber { get; set; }
        /// <summary>
        /// Navigation can be at Pattern or Style level
        /// </summary>
        public virtual Navigation Navigation { get; set; }
        public virtual IList<Style_Locale> StyleInfos { get; set; }

        public Style()
        {
            StyleInfos = new List<Style_Locale>();
        }
    }
}