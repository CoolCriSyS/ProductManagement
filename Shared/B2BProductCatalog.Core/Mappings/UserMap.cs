using B2BProductCatalog.Core.Entities;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Core.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Username)
                .Length(255)
                .Not.Nullable();
            Map(x => x.ApplicationName)
                .Length(255)
                .Not.Nullable();
            Map(x => x.Email)
                .Length(128)
                .Not.Nullable();
            Map(x => x.Comment)
                .Length(255)
                .Nullable();
            Map(x => x.Password)
                .Length(128)
                .Not.Nullable();
            Map(x => x.PasswordQuestion)
                .Length(255)
                .Nullable();
            Map(x => x.PasswordAnswer)
                .Length(255)
                .Nullable();
            Map(x => x.IsApproved)
                .Nullable();
            Map(x => x.LastActivityDate)
                .Nullable();
            Map(x => x.LastLoginDate)
                .Nullable();
            Map(x => x.LastPasswordChangedDate)
                .Nullable();
            Map(x => x.CreationDate)
                .Nullable();
            Map(x => x.IsOnline)
                .Nullable();
            Map(x => x.IsLockedOut)
                .Nullable();
            Map(x => x.LastLockedOutDate)
                .Nullable();
            Map(x => x.FailedPasswordAttemptCount)
                .Nullable();
            Map(x => x.FailedPasswordAttemptWindowStart)
                .Nullable();
            Map(x => x.FailedPasswordAnswerAttemptCount)
                .Nullable();
            Map(x => x.FailedPasswordAnswerAttemptWindowStart)
                .Nullable();
            Map(x => x.PrevLoginDate)
                .Nullable();
            References(x => x.Brand, "BrandId")
                .Not.Nullable()
                .Class(typeof(Brand))
                .ForeignKey("FK_Users_Brand");
        }
    }
}
