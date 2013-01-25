using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class BrandMap : ClassMap<Brand>
    {
        public BrandMap()
        {
            Table("Brand");
            Id(x => x.Id);
            Map(x => x.Name)
                .Length(30)
                .Not.Nullable();
            Map(x => x.B2CBrandName)
                .Length(30)
                .Not.Nullable();
            Map(x => x.Password)
                .Length(15)
                .Not.Nullable();
            HasMany(x => x.BrandInfos)
                .Inverse()
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .ForeignKeyCascadeOnDelete()
                .KeyColumn("BrandId");
        }
    }
}
