using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ItemAllRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ItemAllResponse>>
{
    public IValidator<ItemAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ItemAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

