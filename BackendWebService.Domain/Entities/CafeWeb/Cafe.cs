using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Cafe : BaseEntity
{
    [Required, StringLength(50)]
    public string CafeCode { get; set; }

    [Required]
    public virtual Menu Menu { get; set; }

    public virtual List<Table> Tables { get; set; } = new();

    public virtual List<Receipt> Receipts { get; set; } = new();

    public virtual List<Order> Orders { get; set; } = new();
}
