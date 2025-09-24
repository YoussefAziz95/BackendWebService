using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CaseRequest(
int ActionIndex,
int WorkflowId,
int StatusId,
int? CompanySupplierId,
int? UserId) : IRequest<CaseResponse>
{
    public IValidator<CaseRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CaseRequest> validator)
    {
        throw new NotImplementedException();
    }
}

