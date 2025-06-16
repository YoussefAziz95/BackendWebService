
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum VerificationEnum
{
    [Display(Name = "Email", Description = "التحقق عبر البريد الإلكتروني")]
    Email = 1,

    [Display(Name = "Phone", Description = "التحقق عبر رقم الهاتف")]
    Phone = 2
}

