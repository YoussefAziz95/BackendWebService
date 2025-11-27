using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Address")]
public class Address : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public new int OrganizationId { get; set; }
    public bool IsAdministration { get; set; }
    [Required]
    public string FullAddress { get; set; }
    public string? Street { get; set; }
    public string? Zone { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}
