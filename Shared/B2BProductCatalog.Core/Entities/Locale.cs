using System;

namespace B2BProductCatalog.Core.Entities
{
    public class Locale
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }

        protected Locale() { }

        public Locale(int localeId)
        {
            Id = localeId;
        }
    }

    public enum LocaleEnum
    {
        USA = 1,
        Canada = 2
    }
}
