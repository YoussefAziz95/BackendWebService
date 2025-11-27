using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ContactAllRequest(
int OrganizationId,
string? Value,
string? Type,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ContactAllResponse>>
{
    public IValidator<ContactAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ContactAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

