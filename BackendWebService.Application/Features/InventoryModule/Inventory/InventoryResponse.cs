using Application.Profiles;

namespace Application.Features;
public record InventoryResponse(
string Name,
int? CategoryId,
List<StorageUnitResponse> StorageUnits,
List<ItemResponse> Items): IConvertibleFromEntity<Inventory, InventoryResponse>        
{
public static InventoryResponse FromEntity(Inventory Inventory) =>
new InventoryResponse(
Inventory.Name,
Inventory.CategoryId,
Inventory.StorageUnits.Select(StorageUnitResponse.FromEntity).ToList(),
Inventory.Items.Select(ItemResponse.FromEntity).ToList()
);
}