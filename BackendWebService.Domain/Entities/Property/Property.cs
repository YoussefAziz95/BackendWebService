using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Property")]
public class Property : BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public int AddressId { get; set; }
    [ForeignKey("AddressId")]
    public virtual Address Address { get; set; } 

    [Required, Range(-90, 90)]
    public double Latitude { get; set; }
    [Required, Range(-180, 180)]
    public double Longitude { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}