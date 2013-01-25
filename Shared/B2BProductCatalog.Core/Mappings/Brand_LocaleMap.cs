using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class Brand_LocaleMap : ClassMap<Brand_Locale>
    {
        public Brand_LocaleMap()
        {
            Table("Brand_Locale");
            Id(x => x.Id);
            References(x => x.Brand, "BrandId")
                .Not.Nullable()
                .Class(typeof(Brand))
                .ForeignKey("FK_Brand_Locale_Brand");
            References(x => x.Locale, "LocaleId")
                .Not.Nullable()
                .Class(typeof(Locale))
                .ForeignKey("FK_Brand_Locale_Locale");
            Map(x => x.SalesOrganization)
                .Column("SalesOrg")
                .Length(4)
                .Not.Nullable();
            Map(x => x.DistributionChannel)
                .Column("DistChan")
                .Length(2)
                .Not.Nullable();
        }
    }
}
