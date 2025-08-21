using Domain.Enums;

namespace Application.Features;
public record AddStorageUnitRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit
    );