using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddStorageUnitRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit):IConvertibleToEntity<StorageUnit>
{
public StorageUnit ToEntity() => new StorageUnit
{
InventoryId = InventoryId,
PortionTypeId = PortionTypeId,
FullQuantity = FullQuantity,
Unit= Unit,
};
}