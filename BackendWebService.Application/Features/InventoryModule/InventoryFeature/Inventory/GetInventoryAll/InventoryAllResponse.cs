using Application.Profiles;

namespace Application.Features; 
public record InventoryAllResponse(
string Name,
int? CategoryId) : IConvertibleFromEntity<Inventory, InventoryAllResponse>
{
    public static InventoryAllResponse FromEntity(Inventory Inventory) =>
    new InventoryAllResponse(
    Inventory.Name,
    Inventory.CategoryId);
}

