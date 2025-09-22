using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record WorkflowCycleAllRequest(
WorkflowCycleAllResponse WorkflowCycleAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<WorkflowCycleAllResponse>>, IRequest<int>
{
    public IValidator<WorkflowCycleAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<WorkflowCycleAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

