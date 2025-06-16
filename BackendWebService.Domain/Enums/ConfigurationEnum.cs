using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum ConfigurationEnum
    {
        [Display(Name = "LDAPConfig", Description = "إعدادات LDAP")]
        LDAPConfig = 1,

        [Display(Name = "MicrosoftConfig", Description = "إعدادات Microsoft")]
        MicrosoftConfig = 2,

        [Display(Name = "GoogleConfig", Description = "إعدادات Google")]
        GoogleConfig = 3,
    }
}
