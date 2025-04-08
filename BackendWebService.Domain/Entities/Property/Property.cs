
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Property")]
public class Property : BaseEntity, IEntity, ITimeModification
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public string FullAddress { get; set; } 

    [Required, Range(-90, 90)]
    public double Latitude { get; set; }
    [Required, Range(-180, 180)]
    public double Longitude { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}