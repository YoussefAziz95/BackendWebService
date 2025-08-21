using Domain.Enums;

namespace Application.Features;
public record StorageUnitAllResponse(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit
    );