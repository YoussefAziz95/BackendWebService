using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CaseActionRequest(
int? Order,
int? WorkflowActorId,
int CaseId,
int WorkflowCycleId,
int StatusId) : IRequest<CaseActionResponse>
{
public IValidator<CaseActionRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CaseActionRequest> validator)
{
throw new NotImplementedException();
}
}

