using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CaseActionResponse(
int? Order,
int? WorkflowActorId,
UserResponse? WorkflowActor,
int CaseId,
CaseResponse Case,
int WorkflowCycleId,
WorkflowCycleResponse WorkflowCycle,
int StatusId): IConvertibleFromEntity<CaseAction, CaseActionResponse>
{
public static CaseActionResponse FromEntity(CaseAction CaseAction) =>
new CaseActionResponse(
CaseAction.Order,
CaseAction.WorkflowActorId,
CaseAction.WorkflowActor.ToEntity(),
CaseAction.CaseId,
CaseAction.Case.ToEntity(),
CaseAction.WorkflowCycleId,
CaseAction.WorkflowCycle.ToEntity(),
CaseAction.StatusId);
}