using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CompanyCategoryAllRequest(
int CompanyId,
int? CategoryId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CompanyCategoryAllResponse>>
{
    public IValidator<CompanyAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CompanyCategoryAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

