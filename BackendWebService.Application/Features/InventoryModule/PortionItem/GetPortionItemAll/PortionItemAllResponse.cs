using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PortionItemAllResponse(
int PortionId,
 int ItemId) : IConvertibleFromEntity<PortionItem, PortionItemAllResponse>
{
    public static PortionItemAllResponse FromEntity(PortionItem PortionItem) =>
    new PortionItemAllResponse(
    PortionItem.PortionId,
    PortionItem.ItemId);
}

