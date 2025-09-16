using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateCaseActionRequest(
int? Order,
int? WorkflowActorId,
UpdateUserRequest? WorkflowActor,
int CaseId,
UpdateCaseRequest Case,
int WorkflowCycleId,
UpdateWorkflowCycleRequest WorkflowCycle,
int StatusId) : IConvertibleToEntity<CaseAction>
{
public CaseAction ToEntity() => new CaseAction
{
Order = Order,
WorkflowActorId = WorkflowActorId,
WorkflowActor = WorkflowActor.ToEntity(),
CaseId = CaseId,
Case = Case.ToEntity(),
WorkflowCycleId = WorkflowCycleId,
WorkflowCycle = WorkflowCycle.ToEntity(),
StatusId = StatusId

};
}