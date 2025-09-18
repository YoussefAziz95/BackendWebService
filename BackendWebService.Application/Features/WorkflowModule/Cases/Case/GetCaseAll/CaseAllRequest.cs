using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CaseAllRequest(
int ActionIndex,
int WorkflowId,
int StatusId,
int? CompanySupplierId,
int? UserId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CaseAllResponse>>
{
    public IValidator<CaseAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CaseAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

