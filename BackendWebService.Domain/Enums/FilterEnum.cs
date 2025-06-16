using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum FilterEnum
{
    [Display(Name = "Zone", Description = "المنطقة")]
    Zone,

    [Display(Name = "Property", Description = "الخاصية")]
    Property
}
