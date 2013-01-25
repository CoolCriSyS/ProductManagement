using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class StyleMap : ClassMap<Style>
    {
        public StyleMap()
        {
            Table("Style");
            Id(x => x.Id);
            References(x => x.Pattern, "PatternId")
                .Not.Nullable()
                .Class(typeof(Pattern))
                .ForeignKey("FK_Style_Pattern");
            Map(x => x.StyleNumber)
                .Length(20)
                .Not.Nullable();
            References(x => x.Navigation, "NavigationId")
                .Class(typeof(Navigation))
                .ForeignKey("FK_Style_Navigation");
            HasMany(x => x.StyleInfos)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("StyleId");
        }
    }
}