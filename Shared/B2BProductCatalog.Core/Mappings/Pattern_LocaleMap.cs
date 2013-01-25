using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class Pattern_LocaleMap : ClassMap<Pattern_Locale>
    {
        public Pattern_LocaleMap()
        {
            Table("Pattern_Locale");
            Id(x => x.Id);
            References(x => x.Pattern, "PatternId")
                .Not.Nullable()
                .Class(typeof(Pattern))
                .ForeignKey("FK_Pattern_Locale_Pattern");
            References(x => x.Locale, "LocaleId")
                .Not.Nullable()
                .Class(typeof(Locale))
                .ForeignKey("FK_Pattern_Locale_Locale");
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.MarketingDescription)
                .Column("Description")
                .Length(4000)
                .Nullable();
            Map(x => x.Keywords)
                .Length(100)
                .Nullable();
            Map(x => x.SAPPatternId)
                .Length(20)
                .Nullable();
            Map(x => x.PatternLabel1)
                .Length(50)
                .Nullable();
            Map(x => x.PatternLabel2)
                .Length(50)
                .Nullable();
        }
    }
}
