using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Property")]
public class Property : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ContactName { get; set; }

    [Phone, MaxLength(20)]
    public string ContactNumber { get; set; }

    public int? ZoneId { get; set; }

    [ForeignKey(nameof(ZoneId))]
    public Zone? Zone { get; set; }

    [Required, Range(-90, 90)]
    public double Latitude { get; set; }

    [Required, Range(-180, 180)]
    public double Longitude { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? DeletedAt { get; set; }

    public bool IsDeleted { get; set; } = false;
}
