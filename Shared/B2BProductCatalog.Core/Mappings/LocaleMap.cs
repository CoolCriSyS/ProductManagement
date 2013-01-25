using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class LocaleMap : ClassMap<Locale>
    {
        public LocaleMap()
        {
            Table("Locale");
            Id(x => x.Id);
            Map(x => x.Name)
                .Length(10)
                .Not.Nullable();
            Map(x => x.DisplayName)
                .Length(30)
                .Not.Nullable();
        }
    }
}
