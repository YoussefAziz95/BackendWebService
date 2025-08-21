using Domain.Enums;

namespace Application.Features;
public record GetPaginatedStorageUnit(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit
    );