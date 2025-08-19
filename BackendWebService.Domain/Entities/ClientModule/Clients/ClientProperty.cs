using Domain;
using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ClientProperty")]
public class ClientProperty : BaseEntity, IEntity, ITimeModification
{
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Client Customer { get; set; }

    public int PropertyId { get; set; }

    [ForeignKey("PropertyId")]
    public Property Property { get; set; }

    public int AddressId { get; set; }

    [ForeignKey("AddressId")]
    public Address Address { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [MaxLength(50)]
    public string? Country { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
