using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddPortionRequest(
int Quantity,
int StorageUnitId,
AddStorageUnitRequest StorageUnit,
int PortionTypeId,
AddPortionTypeRequest PortionType,
SizeEnum Size,
List<AddPortionItemRequest> PortionItems):IConvertibleToEntity<Portion>
{
public Portion ToEntity() => new Portion
{
Quantity = Quantity,
StorageUnitId = StorageUnitId,
StorageUnit = StorageUnit.ToEntity(),
PortionTypeId = PortionTypeId,
PortionType = PortionType.ToEntity(),
Size = Size,
PortionItems= PortionItems.Select(x => x.ToEntity()).ToList()
};
}