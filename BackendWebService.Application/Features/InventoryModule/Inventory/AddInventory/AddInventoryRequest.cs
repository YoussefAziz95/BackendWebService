using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;

public record AddInventoryRequest(
string Name,
int? CategoryId,
List<AddStorageUnitRequest> StorageUnits,
List<AddItemRequest> Items) : IConvertibleToEntity<Inventory>, IRequest<int>
{
    public Inventory ToEntity() => new Inventory
    {
        Name = Name,
        CategoryId = CategoryId,
        StorageUnits = StorageUnits.Select(x => x.ToEntity()).ToList(),
        Items = Items.Select(x => x.ToEntity()).ToList()
    };
}