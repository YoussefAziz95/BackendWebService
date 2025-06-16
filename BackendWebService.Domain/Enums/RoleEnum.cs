using System.ComponentModel.DataAnnotations;


public enum RoleEnum
{
    [Display(Name = "SuperAdmin", Description = "مدير النظام الأعلى")]
    SuperAdmin = 1,

    [Display(Name = "Admin", Description = "مسؤول النظام")]
    Admin = 2,

    [Display(Name = "Employee", Description = "موظف داخلي")]
    Employee = 3,

    [Display(Name = "Customer", Description = "عميل خارجي")]
    Customer = 4,

    [Display(Name = "Freelance", Description = "موظف مستقل")]
    Freelance = 5,

    [Display(Name = "OutsourcedEmployee", Description = "موظف خارجي")]
    OutsourcedEmployee = 6,

    [Display(Name = "المدير العام")]
    General,

    [Display(Name = "مدير المبيعات")]
    Sales,

    [Display(Name = "مدير المصنع")]
    Factory,

    [Display(Name = "المدير التنفيذي")]
    Executive,

    [Display(Name = "مدير العمليات")]
    Operations,

    [Display(Name = "المدير الإداري")]
    AdminManager,

    [Display(Name = "مدير التسويق")]
    Marketing,

    [Display(Name = "المدير المالى")]
    Financial,

    [Display(Name = "مدير التصدير")]
    Export,

    [Display(Name = "المدير التجارى")]
    Commercial,

    [Display(Name = "مدير المهمات")]
    Missions,

    [Display(Name = "مدير البحوث والتطوير")]
    RAndD,

    [Display(Name = "مدير المشتريات")]
    Procurement,

    [Display(Name = "مدير الإنتاج")]
    Production
}
