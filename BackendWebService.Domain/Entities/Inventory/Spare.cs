using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Spare")]
public class Spare : BaseEntity, IEntity, ITimeModification
{

    public bool? isAvailable { get; set; }
    public int? RequiredAmount { get; set; }
    public int? AvailableAmount { get; set; }
    public int? ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}
