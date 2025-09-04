using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record StorageUnitAllResponse(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit): IConvertibleFromEntity<StorageUnit, StorageUnitAllResponse>        
{
public static StorageUnitAllResponse FromEntity(StorageUnit StorageUnit) =>
new StorageUnitAllResponse(
StorageUnit.InventoryId,
StorageUnit.PortionTypeId,
StorageUnit.FullQuantity,
StorageUnit.Unit);
}