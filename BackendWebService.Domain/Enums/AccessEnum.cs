using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum AccessEnum
{
    [Display(Description = "عام")]
    Public = 1,

    [Display(Description = "خاص")]
    Private = 2
}
