using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Item : BaseEntity
{
    [Required, StringLength(100)]
    public string ItemName { get; set; }

    [StringLength(500)]
    public string? ItemDescription { get; set; }

    public virtual List<Portion> Portions { get; set; } = new();

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [Required]
    public virtual Category Category { get; set; }

    [Range(0, 180)] // Prevents unrealistic values
    public int PreparationTimeMinutes { get; set; }
}
