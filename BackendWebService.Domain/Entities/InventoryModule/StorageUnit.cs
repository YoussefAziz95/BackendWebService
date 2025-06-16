using Domain.Enums;

namespace Domain;

public class StorageUnit : BaseEntity
{
    public PortionType? PortionType { get; set; }
    public int FullQuantity { get; set; }
    public UnitEnum unit { get; set; }
}
