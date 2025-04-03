
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Member")]
public class Member : BaseEntity, IEntity, ITimeModification
{
    [Key]
    public int Id { get; set; }  // Primary Key
    [Required]

    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }  // Relationship with Customer
    [Required]

    public int FamilyId { get; set; }
    public virtual Family Family { get; set; }  // Relationship with Family
    [ForeignKey("FamilyId")]

    [Required, MaxLength(100)]
    public bool IsActive { get; set; } = true;  // To manage active/inactive members
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Creation timestamp
    public DateTime? UpdatedAt { get; set; }  // Update timestamp
}

