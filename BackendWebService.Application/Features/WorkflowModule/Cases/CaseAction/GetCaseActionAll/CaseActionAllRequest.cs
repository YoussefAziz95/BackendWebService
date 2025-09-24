using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CaseActionAllRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CaseActionAllResponse>>
{
    public IValidator<CaseActionAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CaseActionAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

