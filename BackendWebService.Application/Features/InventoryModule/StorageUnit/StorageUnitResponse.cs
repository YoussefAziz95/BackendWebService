using Domain.Enums;

namespace Application.Features;
public record StorageUnitResponse(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit);