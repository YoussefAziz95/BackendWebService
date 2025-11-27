using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record WorkflowAllRequest(
string? Name,
string? Description,
int? UserId,
int? CompanyId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<WorkflowAllResponse>>
{
    public IValidator<WorkflowAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<WorkflowAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

