using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

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

    [Display(Name = "System", Description = "نظام أساسي")]
    System = 5,

    [Display(Name = "Inventory", Description = "إدارة المخزون")]
    Inventory = 6,

    [Display(Name = "Identity", Description = "إدارة الهوية")]
    Identity = 7,

    [Display(Name = "Freelance", Description = "موظف مستقل")]
    Freelance = 8,

    [Display(Name = "OutsourcedEmployee", Description = "موظف خارجي")]
    OutsourcedEmployee = 9,

    [Display(Name = "General", Description = "المدير العام")]
    General = 10,

    [Display(Name = "Sales", Description = "مدير المبيعات")]
    Sales = 11,

    [Display(Name = "Factory", Description = "مدير المصنع")]
    Factory = 12,

    [Display(Name = "Executive", Description = "المدير التنفيذي")]
    Executive = 13,

    [Display(Name = "Operations", Description = "مدير العمليات")]
    Operations = 14,

    [Display(Name = "AdminManager", Description = "المدير الإداري")]
    AdminManager = 15,

    [Display(Name = "Marketing", Description = "مدير التسويق")]
    Marketing = 16,

    [Display(Name = "Financial", Description = "المدير المالى")]
    Financial = 17,

    [Display(Name = "Export", Description = "مدير التصدير")]
    Export = 18,

    [Display(Name = "Commercial", Description = "المدير التجارى")]
    Commercial = 19,

    [Display(Name = "Missions", Description = "مدير المهمات")]
    Missions = 20,

    [Display(Name = "RAndD", Description = "مدير البحوث والتطوير")]
    RAndD = 21,

    [Display(Name = "Procurement", Description = "مدير المشتريات")]
    Procurement = 22,

    [Display(Name = "Production", Description = "مدير الإنتاج")]
    Production = 23
}
