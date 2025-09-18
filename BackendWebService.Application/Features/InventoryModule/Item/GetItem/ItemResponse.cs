using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ItemResponse(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
List<PortionItemResponse> PortionItems) : IConvertibleFromEntity<Item, ItemResponse>
{
    public static ItemResponse FromEntity(Item Item) =>
    new ItemResponse(
    Item.Name,
    Item.Description,
    Item.UnitPrice,
    Item.CategoryId,
    Item.PreparationTimeMinutes,
    Item.PortionItems.Select(PortionItemResponse.FromEntity).ToList()
    );
}