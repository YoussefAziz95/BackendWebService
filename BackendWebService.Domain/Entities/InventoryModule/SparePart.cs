using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("SparePart")]
public class SparePart : BaseEntity, IEntity, ITimeModification
{
    public required int PartId { get; set; }
    public int? SpareId { get; set; }
    [ForeignKey("PartId")]
    public Part Part { get; set; }
    [ForeignKey("SpareId")]
    public Spare? Spare { get; set; }
}
