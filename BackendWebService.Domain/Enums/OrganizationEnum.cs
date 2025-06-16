using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum OrganizationEnum
{
    [Display(Name = "Organization", Description = "منظمة عامة أو جهة إدارية")]
    Organization = 1,

    [Display(Name = "Company", Description = "شركة أو كيان تجاري")]
    Company = 2,

    [Display(Name = "Supplier", Description = "مورد أو جهة توريد")]
    Supplier = 3,
}
