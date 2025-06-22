using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum ContactEnum
{
    [Display(Name = "Extension", Description = "تحويلة")]
    Extension,

    [Display(Name = "Mobile", Description = "جوال")]
    Mobile,

    [Display(Name = "Hotline", Description = "الخط الساخن")]
    Hotline
}
