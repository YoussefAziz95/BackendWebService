using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum CurrencyEnum
{
    [Display(Name = "EGP", Description = "الجنيه المصري")]
    EGP = 1,

    [Display(Name = "USD", Description = "الدولار الأمريكي")]
    USD = 2,

    [Display(Name = "EUR", Description = "اليورو")]
    EUR = 3,

    [Display(Name = "GBP", Description = "الجنيه الإسترليني")]
    GBP = 4,

    [Display(Name = "JPY", Description = "الين الياباني")]
    JPY = 5
}
