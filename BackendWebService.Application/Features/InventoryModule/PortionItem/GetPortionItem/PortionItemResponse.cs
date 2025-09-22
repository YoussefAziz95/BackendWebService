using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PortionItemResponse(
int PortionId,
 int ItemId,
PortionResponse Portion,
  ItemResponse Item) : IConvertibleFromEntity<PortionItem, PortionItemResponse>
{
    public static PortionItemResponse FromEntity(PortionItem PortionItem) =>
    new PortionItemResponse(
    PortionItem.PortionId,
    PortionItem.ItemId,
    PortionResponse.FromEntity(PortionItem.Portion),
    ItemResponse.FromEntity(PortionItem.Item));
}
