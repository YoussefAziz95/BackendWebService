using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain;

[Table("Zone")]
[Index(nameof(ParentZoneId))]
public class Zone : BaseEntity, IEntity, ITimeModification
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public string? Description { get; set; }

    public int? ParentZoneId { get; set; }

    [ForeignKey("ParentZoneId")]
    public Zone? ParentZone { get; set; }

    [InverseProperty("ParentZone")]
    public ICollection<Zone> SubZones { get; set; } = new List<Zone>();
}
