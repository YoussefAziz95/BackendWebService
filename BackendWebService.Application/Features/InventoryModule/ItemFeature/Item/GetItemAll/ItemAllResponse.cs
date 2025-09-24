using Application.Profiles;
using Domain;

namespace Application.Features; 
public record ItemAllResponse(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes) : IConvertibleFromEntity<Item, ItemAllResponse>
{
    public static ItemAllResponse FromEntity(Item Item) =>
    new ItemAllResponse(
    Item.Name,
    Item.Description,
    Item.UnitPrice,
    Item.CategoryId,
    Item.PreparationTimeMinutes);
}

