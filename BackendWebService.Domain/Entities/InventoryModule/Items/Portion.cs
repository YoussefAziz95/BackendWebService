using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Portion : BaseEntity
{
    [Required]
    public int Quantity { get; set; }

    [Required]
    public int StorageUnitId { get; set; }

    [ForeignKey(nameof(StorageUnitId))]
    public StorageUnit StorageUnit { get; set; }

    [Required]
    public int PortionTypeId { get; set; }

    [ForeignKey(nameof(PortionTypeId))]
    public PortionType PortionType { get; set; }

    [Required]
    public SizeEnum PortionSize { get; set; } // Enum for portion size
}
