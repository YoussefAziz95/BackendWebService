
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum StatusEnum
{
    [Display(Name = "Saved", Description = "تم الحفظ")]
    Saved = 0,

    [Display(Name = "New", Description = "جديد")]
    New = 1,

    [Display(Name = "Hold", Description = "معلّق")]
    Hold = 2,

    [Display(Name = "Active", Description = "نشط")]
    Active = 3,

    [Display(Name = "Scored", Description = "تم التقييم")]
    Scored = 4,

    [Display(Name = "Returned", Description = "تم الإرجاع")]
    Returned = 5,

    [Display(Name = "Accepted", Description = "تم القبول")]
    Accepted = 6,

    [Display(Name = "PendingApproval", Description = "بانتظار الموافقة")]
    PendingApproval = 7,

    [Display(Name = "Disabled", Description = "معطل")]
    Disabled = 8,

    [Display(Name = "Suspended", Description = "موقوف مؤقتاً")]
    Suspended = 9,

    [Display(Name = "Deleted", Description = "محذوف")]
    Deleted = 10,

    [Display(Name = "OnTheWay", Description = "في الطريق")]
    OnTheWay = 11,

    [Display(Name = "Arrived", Description = "تم الوصول")]
    Arrived = 12,

    [Display(Name = "InProgress", Description = "قيد التنفيذ")]
    InProgress = 13,

    [Display(Name = "Completed", Description = "مكتمل")]
    Completed = 14,

    [Display(Name = "IssueReported", Description = "تم الإبلاغ عن مشكلة")]
    IssueReported = 15,

    [Display(Name = "Pending", Description = "قيد الانتظار")]
    Pending = 16
}
