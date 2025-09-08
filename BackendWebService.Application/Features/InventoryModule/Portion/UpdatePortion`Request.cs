using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdatePortionRequest(
int Quantity,
int StorageUnitId,
UpdateStorageUnitRequest StorageUnit,
int PortionTypeId,
UpdatePortionTypeRequest PortionType,
SizeEnum Size,
List<UpdatePortionItemRequest> PortionItems):IConvertibleToEntity<Portion>
{
public Portion ToEntity() => new Portion
{
Quantity = Quantity,
StorageUnitId = StorageUnitId,
StorageUnit = StorageUnit.ToEntity(),
PortionTypeId = PortionTypeId,
PortionType = PortionType.ToEntity(),
Size = Size,
PortionItems = PortionItems.Select(x => x.ToEntity()).ToList()
};
}