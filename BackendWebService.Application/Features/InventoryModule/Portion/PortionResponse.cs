using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PortionResponse(
int Quantity,
int StorageUnitId,
StorageUnitResponse StorageUnit,
int PortionTypeId,
PortionTypeResponse PortionType,
SizeEnum Size,
List<PortionItemResponse> PortionItems):IConvertibleFromEntity<Portion, PortionResponse>
{
public static PortionResponse FromEntity(Portion Portion) =>
new PortionResponse(
Portion.Quantity,
Portion.StorageUnitId,
Portion.PortionTypeId,
Portion.Size,
Portion.StorageUnit.ToEntity(),
Portion.PortionType.ToEntity());
}