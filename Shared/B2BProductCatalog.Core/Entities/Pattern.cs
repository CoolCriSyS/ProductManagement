using System;
using System.Collections.Generic;

namespace B2BProductCatalog.Core.Entities
{
    public class Pattern
    {
        public virtual int Id { get; private set; }
        public virtual Brand Brand { get; set; }
        /// <summary>
        /// Navigation can be at Pattern or Style level
        /// </summary>
        public virtual Navigation Navigation { get; set; }
        public virtual IList<Pattern_Locale> PatternInfos { get; set; }
        public virtual IList<Style> Styles { get; set; }

        public Pattern()
        {
            Navigation = new Navigation{Pattern = this};
            PatternInfos = new List<Pattern_Locale>();
            Styles = new List<Style>();
        }
    }
}
