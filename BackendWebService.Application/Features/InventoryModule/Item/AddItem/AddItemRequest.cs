using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddItemRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
List<AddPortionItemRequest> PortionItems) : IConvertibleToEntity<Item>, IRequest<int>
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