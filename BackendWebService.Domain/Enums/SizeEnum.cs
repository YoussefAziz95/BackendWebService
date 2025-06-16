using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum SizeEnum
{
    [Display(Name = "Small", Description = "صغير")]
    Small = 1,

    [Display(Name = "Medium", Description = "متوسط")]
    Medium = 2,

    [Display(Name = "Large", Description = "كبير")]
    Large = 3,

    [Display(Name = "ExtraLarge", Description = "كبير جدًا")]
    ExtraLarge = 4
}