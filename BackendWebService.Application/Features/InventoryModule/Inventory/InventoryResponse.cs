namespace Application.Features;
public record InventoryResponse(
string Name,
int? CategoryId,
List<StorageUnitResponse> StorageUnits,
List<ItemResponse> Items);