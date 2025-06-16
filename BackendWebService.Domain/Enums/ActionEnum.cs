using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum ActionEnum
{
    // Initial Actions
    [Display(Name = "طلب")]
    Request = 1,

    [Display(Name = "تعيين")]
    Assign = 2,

    [Display(Name = "تحويل")]
    Forward = 3,

    // Processing Actions
    [Display(Name = "بدء")]
    Start = 4,

    [Display(Name = "فتح")]
    Open = 5,

    [Display(Name = "استئناف")]
    Resume = 6,

    [Display(Name = "إعادة فتح")]
    Reopen = 7,

    // Temporary Pauses
    [Display(Name = "إيقاف مؤقت")]
    Pause = 8,

    [Display(Name = "تعليق")]
    Hold = 9,

    [Display(Name = "إلغاء التعليق")]
    Unhold = 10,

    [Display(Name = "إيقاف")]
    Suspend = 11,

    // Task Completion or Decision Making
    [Display(Name = "مراجعة")]
    Review = 12,

    [Display(Name = "تقييم")]
    Score = 13,

    [Display(Name = "موافقة")]
    Approve = 14,

    [Display(Name = "رفض")]
    Reject = 15,

    [Display(Name = "إنهاء")]
    Complete = 16,

    // Payment & Financial Actions
    [Display(Name = "دفع")]
    Payment = 17,

    // Task Cancellation or Closure
    [Display(Name = "سحب")]
    Withdraw = 18,

    [Display(Name = "إلغاء")]
    Cancel = 19,

    [Display(Name = "إرجاع")]
    Return = 20,

    [Display(Name = "إغلاق")]
    Close = 21,

    [Display(Name = "إيقاف نهائي")]
    Stop = 22
}