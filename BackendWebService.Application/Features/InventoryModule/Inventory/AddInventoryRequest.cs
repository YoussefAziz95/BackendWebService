namespace Application.Features;
public record AddInventoryRequest(
string Name,
int? CategoryId,
List<AddStorageUnitRequest> StorageUnits,
List<AddItemRequest> Items);