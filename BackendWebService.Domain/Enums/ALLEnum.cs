using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum ALLEnum
    {
        [Display(Description = "الإجراءات")]
        ActionEnum,

        [Display(Description = "الصلاحيات")]
        AccessEnum,

        [Display(Description = "الجهة الفاعلة")]
        ActorEnum,

        [Display(Description = "كود نتيجة الواجهة")]
        ApiResultStatusCode,

        [Display(Description = "التوافر")]
        AvailabilityEnum,

        [Display(Description = "الإعدادات")]
        ConfigurationEnum,

        [Display(Description = "العملة")]
        CurrencyEnum,

        [Display(Description = "خصائص العرض")]
        DisplayProperty,

        [Display(Description = "أنواع الاستثناءات")]
        ExceptionEnum,

        [Display(Description = "أنواع الملفات")]
        FileTypeEnum,

        [Display(Description = "عامل التصفية")]
        FilterEnum,

        [Display(Description = "اللغة")]
        LanguageEnum,

        [Display(Description = "المنظمة")]
        OrganizationEnum,

        [Display(Description = "الدفع")]
        PaymentEnum,

        [Display(Description = "الأدوار")]
        RoleEnum,

        [Display(Description = "الحجم")]
        SizeEnum,

        [Display(Description = "الحالة")]
        StatusEnum,

        [Display(Description = "اسم الجدول")]
        TableNameEnum,

        [Display(Description = "المعاملة")]
        TransactionEnum,

        [Display(Description = "الوحدة")]
        UnitEnum,

        [Display(Description = "التحقق")]
        ValidatorEnum,

        [Display(Description = "التوثيق")]
        VerificationEnum,

        [Display(Description = "جهة الاتصال")]
        ContactEnum,

        [Display(Description = "الإداريون")]
        ManagerEnum,
    }
}
