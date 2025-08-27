using Domain.Enums;

namespace Application.Features;
public record UpdateStorageUnitRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit);