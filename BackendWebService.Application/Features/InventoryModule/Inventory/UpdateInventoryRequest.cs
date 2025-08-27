namespace Application.Features;
public record UpdateInventoryRequest(
string Name,
int? CategoryId,
List<UpdateStorageUnitRequest> StorageUnits,
List<UpdateItemRequest> Items);