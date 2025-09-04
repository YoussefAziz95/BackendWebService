using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateItemRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
List<UpdatePortionItemRequest> PortionItems):IConvertibleToEntity<Item>
{
public Item ToEntity() => new Item
{
Name = Name,
Description = Description,
UnitPrice = UnitPrice,
CategoryId = CategoryId,
PreparationTimeMinutes = PreparationTimeMinutes,
PortionItems = PortionItems.Select(x => x.ToEntity()).ToList()
};
}