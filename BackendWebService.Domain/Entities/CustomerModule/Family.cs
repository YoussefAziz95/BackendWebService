using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Family")]
public class Family : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    [Required, MaxLength(255)]
    public string Name { get; set; }
    public virtual List<UserGroup> UserGroups { get; set; } = new();
    public int? ActorId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}