using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record StorageUnitResponse(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit) : IConvertibleFromEntity<StorageUnit, StorageUnitResponse>
{
    public static StorageUnitResponse FromEntity(StorageUnit StorageUnit) =>
    new StorageUnitResponse(
    StorageUnit.InventoryId,
    StorageUnit.PortionTypeId,
    StorageUnit.FullQuantity,
    StorageUnit.Unit);
}