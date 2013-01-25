using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class FlagCategoryMap : ClassMap<FlagCategory>
    {
        public FlagCategoryMap()
        {
            Table("FlagCategory");
            Id(x => x.Id);
            References(x => x.Brand, "BrandId")
                .Not.Nullable()
                .Class(typeof(Brand))
                .ForeignKey("FK_FlagCategory_Brand");
            HasMany(x => x.FlagCategoryInfos)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("FlagCategoryId");
        }
    }
}
