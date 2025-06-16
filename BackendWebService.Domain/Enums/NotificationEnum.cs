using System.ComponentModel.DataAnnotations;
namespace Domain.Enums;

public enum NotificationEnum
{
    [Display(Name = "AccountCreated", Description = "تم إنشاء الحساب بنجاح")]
    AccountCreated,

    [Display(Name = "AccountDisabled", Description = "تم تعطيل الحساب")]
    AccountDisabled,

    [Display(Name = "NewJobAssigned", Description = "تم تعيين مهمة جديدة")]
    NewJobAssigned,

    [Display(Name = "JobReassigned", Description = "تم إعادة تعيين المهمة")]
    JobReassigned,

    [Display(Name = "JobCanceled", Description = "تم إلغاء المهمة")]
    JobCanceled,

    [Display(Name = "ServiceDisabled", Description = "تم تعطيل الخدمة")]
    ServiceDisabled
}
