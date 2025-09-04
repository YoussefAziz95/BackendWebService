using Application.Profiles;
using Domain;

namespace Application.Features;
public record PortionItemResponse(
int PortionId,
 int ItemId,
PortionResponse Portion,
  ItemResponse Item):IConvertibleFromEntity<PortionItem, PortionItemResponse>        
{
public static PortionItemResponse FromEntity(PortionItem PortionItem) =>
new PortionItemResponse(
PortionItem.PortionId,
PortionItem.ItemId,
 PortionItem.Portion.ToEntity(),
 PortionItem.Item.ToEntity());
}
