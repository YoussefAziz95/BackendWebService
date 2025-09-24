using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ItemRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes) : IRequest<ItemResponse>
{
    public IValidator<ItemRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ItemRequest> validator)
    {
        throw new NotImplementedException();
    }
}

