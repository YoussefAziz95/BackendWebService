using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddPortionItemRequest(
int PortionId,
 int ItemId,
AddPortionRequest Portion,
 AddItemRequest Item):IConvertibleToEntity<PortionItem>
{
public PortionItem ToEntity() => new PortionItem
{
    PortionId = PortionId,
    ItemId = ItemId,
    Portion = Portion.ToEntity(),
    Item = Item.ToEntity()
};
}