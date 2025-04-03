using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("PropertyZone")]
public class PropertyZone : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int PropertyId { get; set; }
    [Required]
    public int ZoneId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}