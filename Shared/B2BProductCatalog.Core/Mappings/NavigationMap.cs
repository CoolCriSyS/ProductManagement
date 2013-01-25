using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class NavigationMap : ClassMap<Navigation>
    {
        public NavigationMap()
        {
            Table("Navigation");
            Id(x => x.Id);
            References(x => x.Brand, "BrandId")
                .Not.Nullable()
                .Class(typeof(Brand))
                .ForeignKey("FK_Navigation_Brand");
            HasMany(x => x.NavigationInfos)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("NavigationId");
        }
    }
}