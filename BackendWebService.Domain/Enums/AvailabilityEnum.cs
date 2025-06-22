using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum AvailabilityEnum
{
    [Display(Name = "Available", Description = "متاح")]
    Available,

    [Display(Name = "Unavailable", Description = "غير متاح")]
    Unavailable,

    [Display(Name = "OnLeave", Description = "في إجازة")]
    OnLeave,

    [Display(Name = "Busy", Description = "مشغول")]
    Busy,

    [Display(Name = "Offline", Description = "غير متصل")]
    Offline
}
