using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum TableNameEnum
    {
        [Display(Name = "Logging", Description = "سجل الأحداث")]
        Logging,

        [Display(Name = "TranslationKey", Description = "مفاتيح الترجمة")]
        TranslationKey,

        [Display(Name = "Customer", Description = "العميل")]
        Customer,

        [Display(Name = "CustomerAccount", Description = "حساب العميل")]
        CustomerAccount,

        [Display(Name = "CustomerProperty", Description = "عقار العميل")]
        CustomerProperty,

        [Display(Name = "CustomerService", Description = "خدمة العميل")]
        CustomerService,

        [Display(Name = "Family", Description = "الأسرة")]
        Family,

        [Display(Name = "Member", Description = "العضو")]
        Member,

        [Display(Name = "Attachment", Description = "المرفق")]
        Attachment,

        [Display(Name = "EmailLog", Description = "سجل البريد الإلكتروني")]
        EmailLog,

        [Display(Name = "Recipient", Description = "المستلم")]
        Recipient,

        [Display(Name = "ExceptionLog", Description = "سجل الاستثناءات")]
        ExceptionLog,

        [Display(Name = "FileFieldValidator", Description = "محقق صحة الحقول")]
        FileFieldValidator,

        [Display(Name = "FileLog", Description = "سجل الملفات")]
        FileLog,

        [Display(Name = "FileType", Description = "نوع الملف")]
        FileType,

        [Display(Name = "UserRefreshToken", Description = "رمز تجديد الدخول")]
        UserRefreshToken,

        [Display(Name = "Category", Description = "التصنيف")]
        Category,

        [Display(Name = "Part", Description = "الجزء")]
        Part,

        [Display(Name = "Product", Description = "المنتج")]
        Product,

        [Display(Name = "Service", Description = "الخدمة")]
        Service,

        [Display(Name = "Spare", Description = "البديل")]
        Spare,

        [Display(Name = "SparePart", Description = "قطعة الغيار")]
        SparePart,

        [Display(Name = "Notification", Description = "الإشعار")]
        Notification,

        [Display(Name = "NotificationDetail", Description = "تفاصيل الإشعار")]
        NotificationDetail,

        [Display(Name = "Administrator", Description = "المسؤول")]
        Administrator,

        [Display(Name = "AppConfiguration", Description = "إعدادات التطبيق")]
        AppConfiguration,

        [Display(Name = "Company", Description = "الشركة")]
        Company,

        [Display(Name = "GoogleConfig", Description = "إعدادات Google")]
        GoogleConfig,

        [Display(Name = "LDAPConfig", Description = "إعدادات LDAP")]
        LDAPConfig,

        [Display(Name = "MicrosoftConfig", Description = "إعدادات Microsoft")]
        MicrosoftConfig,

        [Display(Name = "Organization", Description = "المنظمة")]
        Organization,

        [Display(Name = "PreDocument", Description = "المستند المسبق")]
        PreDocument,

        [Display(Name = "Supplier", Description = "المورد")]
        Supplier,

        [Display(Name = "SupplierAccount", Description = "حساب المورد")]
        SupplierAccount,

        [Display(Name = "SupplierCategory", Description = "فئة المورد")]
        SupplierCategory,

        [Display(Name = "SupplierDocument", Description = "مستند المورد")]
        SupplierDocument,

        [Display(Name = "PaymentMethod", Description = "طريقة الدفع")]
        PaymentMethod,

        [Display(Name = "Transaction", Description = "المعاملة")]
        Transaction,

        [Display(Name = "Property", Description = "العقار")]
        Property,

        [Display(Name = "Zone", Description = "المنطقة")]
        Zone,

        [Display(Name = "Employee", Description = "الموظف")]
        Employee,

        [Display(Name = "EmployeeAccount", Description = "حساب الموظف")]
        EmployeeAccount,

        [Display(Name = "EmployeeAssignment", Description = "تعيين الموظف")]
        EmployeeAssignment,

        [Display(Name = "EmployeeJob", Description = "وظيفة الموظف")]
        EmployeeJob,

        [Display(Name = "Actor", Description = "الجهة الفاعلة")]
        Actor,

        [Display(Name = "Address", Description = "العنوان")]
        Address,

        [Display(Name = "Group", Description = "المجموعة")]
        Group,

        [Display(Name = "UserGroup", Description = "مجموعة المستخدم")]
        UserGroup,

        [Display(Name = "WAction", Description = "الإجراء")]
        WAction,

        [Display(Name = "Role", Description = "الدور")]
        Role,

        [Display(Name = "RoleClaim", Description = "إذن الدور")]
        RoleClaim,

        [Display(Name = "User", Description = "المستخدم")]
        User,

        [Display(Name = "UserClaim", Description = "إذن المستخدم")]
        UserClaim,

        [Display(Name = "UserLogin", Description = "تسجيل دخول المستخدم")]
        UserLogin,

        [Display(Name = "UserRole", Description = "دور المستخدم")]
        UserRole,

        [Display(Name = "UserToken", Description = "رمز المستخدم")]
        UserToken,

        [Display(Name = "ApplicationDbContext", Description = "قاعدة بيانات التطبيق")]
        ApplicationDbContext
    }
}
