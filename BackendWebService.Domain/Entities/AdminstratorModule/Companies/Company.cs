using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Company")]
public class Company : BaseEntity, IEntity, ITimeModification
{
    public int OrganizationId { get; set; }
    [ForeignKey("OrganizationId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Organization Organization { get; set; }
    public string? CompanyName { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    public string? Chairman { get; set; }   // رئيس مجلس الإدارة
    public string? QualityCertificates { get; set; }  // شهادات الجودة
    public string? ViceChairman { get; set; } // نائب رئيس مجلس الإدارة
    public string? ProductType { get; set; } // نوع المنتج
    public ICollection<CompanyCategory>? Activity { get; set; }   // النشاطات
    public ICollection<Address>? Addresses { get; set; } // العناوين
    public ICollection<Contact>? Contacts { get; set; } // جهات الاتصال
    public ICollection<Manager>? Manager { get; set; } // المديرين
}