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
    public string? Name { get; set; }
    public string? RegistrationNumber { get; set; }
    public Address? Address { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
}