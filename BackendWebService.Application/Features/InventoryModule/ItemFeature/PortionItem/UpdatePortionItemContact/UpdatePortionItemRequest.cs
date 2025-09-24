using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features; 
public record UpdatePortionItemRequest(
int PortionId,
 int ItemId,
UpdatePortionRequest Portion,
 UpdateItemRequest Item) : IConvertibleToEntity<PortionItem>, IRequest<int>
{
    public PortionItem ToEntity() => new PortionItem
    {
        PortionId = PortionId,
        ItemId = ItemId,
        Portion = Portion.ToEntity(),
        Item = Item.ToEntity()
    };
}