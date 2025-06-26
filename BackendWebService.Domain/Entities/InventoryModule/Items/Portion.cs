using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Portion")]
public class Portion : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int Quantity { get; set; }

    [Required]
    public int StorageUnitId { get; set; }

    [ForeignKey(nameof(StorageUnitId))]
    public StorageUnit StorageUnit { get; set; }

    public int PortionTypeId { get; set; }

    [ForeignKey(nameof(PortionTypeId))]
    public PortionType PortionType { get; set; }

    [Required]
    public SizeEnum Size { get; set; }

    public virtual ICollection<PortionItem> PortionItems { get; set; }
}
