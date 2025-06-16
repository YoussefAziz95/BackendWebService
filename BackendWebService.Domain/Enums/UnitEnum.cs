using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum UnitEnum
{
    [Display(Name = "Piece", Description = "قطعة")]
    Piece = 1,

    [Display(Name = "Kg", Description = "كيلوجرام")]
    Kg = 2,

    [Display(Name = "L", Description = "لتر")]
    L = 3,

    [Display(Name = "Ml", Description = "ملليلتر")]
    Ml = 4,

    [Display(Name = "Gr", Description = "جرام")]
    Gr = 5,

    [Display(Name = "Cl", Description = "سنتيلتر")]
    Cl = 6
}
