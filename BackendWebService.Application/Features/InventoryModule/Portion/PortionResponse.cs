using Domain;
using Domain.Enums;

namespace Application.Features;
public record PortionResponse(
int Quantity,
int StorageUnitId,
StorageUnit StorageUnit,
int PortionTypeId,
PortionType PortionType,
SizeEnum Size,
List<PortionItemResponse> PortionItems);