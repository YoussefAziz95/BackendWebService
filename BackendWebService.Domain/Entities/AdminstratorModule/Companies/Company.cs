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
    public string? Chairman { get; set; }
    public string? QualityCertificates { get; set; }
    public string? ViceChairman { get; set; }
    public string? ProductType { get; set; }
    public ICollection<CompanyCategory>? Activity { get; set; }
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<Contact>? Contacts { get; set; }
    public ICollection<Manager>? Manager { get; set; }
}
