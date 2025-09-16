using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ManagerAllRequest(
int OrganizationId,
string Name,
string Position,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ManagerAllResponse>>
{
    public IValidator<ManagerAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ManagerAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

