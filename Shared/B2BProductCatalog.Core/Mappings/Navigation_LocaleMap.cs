using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class Navigation_LocaleMap : ClassMap<Navigation_Locale>
    {
        public Navigation_LocaleMap()
        {
            Table("Navigation_Locale");
            Id(x => x.Id);
            References(x => x.Navigation, "NavigationId")
                .Not.Nullable()
                .Class(typeof(Navigation))
                .ForeignKey("FK_Navigation_Locale_Navigation");
            References(x => x.Locale, "LocaleId")
                .Not.Nullable()
                .Class(typeof(Locale))
                .ForeignKey("FK_Navigation_Locale_Locale");
            Map(x => x.Category1)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Category2)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Category3)
                .Length(50)
                .Nullable();
            Map(x => x.Category4)
                .Length(50)
                .Nullable();
        }
    }
}