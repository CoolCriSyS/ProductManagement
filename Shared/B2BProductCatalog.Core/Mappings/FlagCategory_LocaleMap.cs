using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class FlagCategory_LocaleMap : ClassMap<FlagCategory_Locale>
    {
        public FlagCategory_LocaleMap()
        {
            Table("FlagCategory_Locale");
            Id(x => x.Id);
            References(x => x.FlagCategory, "FlagCategoryId")
                .Not.Nullable()
                .Class(typeof(FlagCategory))
                .ForeignKey("FK_FlagCategory_Locale_FlagCategory");
            References(x => x.Locale, "LocaleId")
                .Not.Nullable()
                .Class(typeof(Locale))
                .ForeignKey("FK_FlagCategory_Locale_Locale");
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Sequence)
                .Nullable();
        }
    }
}
