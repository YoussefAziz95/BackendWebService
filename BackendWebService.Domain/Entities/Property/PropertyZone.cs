using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("PropertyZone")]
public class PropertyZone : BaseEntity
{
    [Required]
    public int PropertyId { get; set; }
    [Required]
    public int ZoneId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}