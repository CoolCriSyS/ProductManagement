using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class B2BExtractMap : ClassMap<B2BExtract>
    {
        public B2BExtractMap()
        {
            Table("B2BExtract");
            Id(x => x.Id);
            Map(x => x.StockNumber)
                .ReadOnly()
                .Length(20)
                .Not.Nullable();
            Map(x => x.StyleName)
                .Column("Description")
                .ReadOnly()
                .Length(50)
                .Nullable();
            Map(x => x.MaterialCreated)
                .ReadOnly()
                .Nullable();
            Map(x => x.SalesOrganization)
                .Column("SalesOrg")
                .ReadOnly()
                .Length(4)
                .Not.Nullable();
            Map(x => x.DistributionChannel)
                .Column("DistChan")
                .ReadOnly()
                .Length(2)
                .Not.Nullable();
            Map(x => x.Division)
                .ReadOnly()
                .Length(2)
                .Nullable();
            Map(x => x.DivisionDesc)
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.FullHierarchy)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy1)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy1Desc)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy2)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy2Desc)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy3)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy3Desc)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy4)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Hierarchy4Desc)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.Status)
                .ReadOnly()
                .Length(2)
                .Nullable();
            Map(x => x.UofM)
                .ReadOnly()
                .Length(5)
                .Nullable();
            Map(x => x.DefaultPlant)
                .ReadOnly()
                .Length(10)
                .Nullable();
            Map(x => x.Season)
                .ReadOnly()
                .Length(10)
                .Nullable();
            Map(x => x.PatternId)
                .ReadOnly()
                .Length(10)
                .Nullable();
            Map(x => x.PatternLabel1)
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.PatternLabel2)
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.BoxLabelColor)
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.GenderId)
                .ReadOnly()
                .Length(2)
                .Nullable();
            Map(x => x.GenderDesc)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.GenderDescFr)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.CollectionId)
                .ReadOnly()
                .Length(20)
                .Nullable();
            Map(x => x.CollectionDesc)
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.PatternName)
                .Column("PatternName")
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.PatternDesc)
                .ReadOnly()
                .Length(30)
                .Nullable();
            Map(x => x.StringInventory)
                .Column("Inventory")
                .ReadOnly()
                .Nullable();
            Map(x => x.StringPOQuantity)
                .Column("POQuantity")
                .ReadOnly()
                .Nullable();
            Map(x => x.Color)
                .ReadOnly()
                .Length(50)
                .Nullable();
            Map(x => x.ColorFr)
                .ReadOnly()
                .Length(50)
                .Nullable();
        }
    }
}