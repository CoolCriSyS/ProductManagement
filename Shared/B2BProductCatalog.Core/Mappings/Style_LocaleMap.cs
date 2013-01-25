using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class Style_LocaleMap : ClassMap<Style_Locale>
    {
        public Style_LocaleMap()
        {
            Table("Style_Locale");
            Id(x => x.Id);
            References(x => x.Style, "Id")
                .Not.Nullable()
                .Class(typeof(Style))
                .ForeignKey("FK_Style_Locale_Style");
            References(x => x.Locale, "LocaleId")
                .Not.Nullable()
                .Class(typeof(Locale))
                .ForeignKey("FK_Style_Locale_Locale");
            Map(x => x.SalesOrg)
                .Length(4)
                .Not.Nullable();
            Map(x => x.DistChan)
                .Length(2)
                .Not.Nullable();
            Map(x => x.Division)
                .Length(2)
                .Not.Nullable();
            Map(x => x.DivisionDesc)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Color)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Description)
                .Length(50)
                .Not.Nullable();
            Map(x => x.MaterialCreated)
                .Not.Nullable();
            Map(x => x.Status)
                .Length(2)
                .Not.Nullable();
            Map(x => x.ActiveDate)
                .Nullable();
            Map(x => x.DefaultPlant)
                .Length(4)
                .Not.Nullable();
            Map(x => x.Season)
                .Length(30)
                .Nullable();
            Map(x => x.GenderId)
                .Length(2)
                .Not.Nullable();
            Map(x => x.GenderDesc)
                .Length(30)
                .Not.Nullable();
            Map(x => x.Inventory)
                .Nullable();
            Map(x => x.POQuantity)
                .Nullable();
            Map(x => x.UofM)
                .Length(10)
                .Nullable();
            Map(x => x.BoxLabelColor)
                .Length(50)
                .Nullable();
        }
    }
}