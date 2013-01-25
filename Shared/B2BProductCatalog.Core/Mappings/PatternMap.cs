using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class PatternMap : ClassMap<Pattern>
    {
        public PatternMap()
        {
            Table("Pattern");
            Id(x => x.Id);
            References(x => x.Brand, "BrandId")
                .Not.Nullable()
                .Class(typeof(Brand))
                .ForeignKey("FK_Pattern_Brand");
            References(x => x.Navigation, "NavigationId")
                .Class(typeof(Navigation))
                .ForeignKey("FK_Pattern_Navigation");
            HasMany(x => x.PatternInfos)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("PatternId");
            HasMany(x => x.Styles)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("Id");
        }
    }
}
