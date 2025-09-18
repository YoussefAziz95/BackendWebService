using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddPortionItemRequest(
int PortionId,
 int ItemId,
AddPortionRequest Portion,
 AddItemRequest Item) : IConvertibleToEntity<PortionItem>, IRequest<int>
{
    public PortionItem ToEntity() => new PortionItem
    {
        PortionId = PortionId,
        ItemId = ItemId,
        Portion = Portion.ToEntity(),
        Item = Item.ToEntity()
    };
}