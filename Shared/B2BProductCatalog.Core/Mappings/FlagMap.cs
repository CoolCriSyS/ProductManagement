using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class FlagMap : ClassMap<Flag>
    {
        public FlagMap()
        {
            Table("Flag");
            Id(x => x.Id);
            References(x => x.Brand, "BrandId")
                .Not.Nullable()
                .Class(typeof(Brand))
                .ForeignKey("FK_Flag_Brand");
            References(x => x.FlagCategory, "FlagCategoryId")
                .Not.Nullable()
                .Class(typeof(FlagCategory))
                .ForeignKey("FK_Flag_FlagCategory");
            Map(x => x.ImagePath)
                .Length(50)
                .Nullable();
            HasMany(x => x.FlagInfos)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("FlagId");
        }
    }
}
