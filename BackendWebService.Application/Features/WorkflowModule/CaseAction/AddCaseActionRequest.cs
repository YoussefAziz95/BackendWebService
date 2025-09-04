using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddCaseActionRequest(
int? Order,
int? WorkflowActorId,
AddUserRequest? WorkflowActor,
int CaseId,
AddCaseRequest Case,
int WorkflowCycleId,
AddWorkflowCycleRequest WorkflowCycle,
int StatusId):IConvertibleToEntity<CaseAction>
{
public CaseAction ToEntity() => new CaseAction
{
Order = Order,
WorkflowActorId = WorkflowActorId,
WorkflowActor = WorkflowActor.ToEntity(),                      
CaseId = CaseId,
Case = Case.ToEntity(),
WorkflowCycleId = WorkflowCycleId,
WorkflowCycle= WorkflowCycle.ToEntity(),
StatusId= StatusId

};
}