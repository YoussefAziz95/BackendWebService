using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("SparePart")]
public class SparePart : BaseEntity, IEntity, ITimeModification
{
    public int PartId { get; set; }

    public int? SpareId { get; set; }

    [ForeignKey(nameof(PartId))]
    public Part Part { get; set; }

    [ForeignKey(nameof(SpareId))]
    public Spare? Spare { get; set; }
}
