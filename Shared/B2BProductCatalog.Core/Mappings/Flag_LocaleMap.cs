using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class Flag_LocaleMap : ClassMap<Flag_Locale>
    {
        public Flag_LocaleMap()
        {
            Table("Flag_Locale");
            Id(x => x.Id);
            References(x => x.Flag, "FlagId")
                .Not.Nullable()
                .Class(typeof(Flag))
                .ForeignKey("FK_Flag_Locale_Flag");
            References(x => x.Locale, "LocaleId")
                .Not.Nullable()
                .Class(typeof(Locale))
                .ForeignKey("FK_Flag_Locale_Locale");
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Description)
                .Length(4000)
                .Not.Nullable();
            Map(x => x.Sequence)
                .Nullable();
        }
    }
}
