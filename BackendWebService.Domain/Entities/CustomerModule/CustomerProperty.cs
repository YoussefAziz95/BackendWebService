using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("CustomerProperty")]
public class CustomerProperty : BaseEntity, IEntity, ITimeModification
{

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }

    public int PropertyId { get; set; }
    [ForeignKey("PropertyId")]
    public virtual Property Property { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public int AddressId { get; set; }
    [ForeignKey("AddressId")]
    public virtual Address Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [MaxLength(50)]
    public string? Country { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
