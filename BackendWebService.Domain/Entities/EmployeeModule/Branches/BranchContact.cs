using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("BranchContact")]
public class BranchContact : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [Required, MaxLength(50)]
    public string Type { get; set; } // E.g., "Phone", "WhatsApp", "Fax", "Email"

    [Required, MaxLength(100)]
    public string Value { get; set; }

    [NotMapped]
    public ContactEnum? ContactType =>
        Enum.TryParse<ContactEnum>(Type, out var parsed) ? parsed : null;
}
