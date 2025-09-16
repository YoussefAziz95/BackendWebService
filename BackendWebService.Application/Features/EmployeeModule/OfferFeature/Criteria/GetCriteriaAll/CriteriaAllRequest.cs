using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CriteriaAllRequest(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CriteriaAllResponse>>
{
    public IValidator<CriteriaAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CriteriaAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

