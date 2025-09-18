using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateStorageUnitRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit) : IConvertibleToEntity<StorageUnit>, IRequest<int>
{
    public StorageUnit ToEntity() => new StorageUnit
    {
        InventoryId = InventoryId,
        PortionTypeId = PortionTypeId,
        FullQuantity = FullQuantity,
        Unit = Unit,
    };
}