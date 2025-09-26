using Application.Profiles;
using Domain;

namespace Application.Features;
public record CaseActionResponse(
int? Order,
int? WorkflowActorId,
UserResponse? WorkflowActor,
int CaseId,
CaseResponse Case,
int WorkflowCycleId,
WorkflowCycleResponse WorkflowCycle,
int StatusId) : IConvertibleFromEntity<CaseAction, CaseActionResponse>
{
    public static CaseActionResponse FromEntity(CaseAction CaseAction) =>
    new CaseActionResponse(
    CaseAction.Order,
    CaseAction.WorkflowActorId,
    UserResponse.FromEntity(CaseAction.WorkflowActor),
    CaseAction.CaseId,
    CaseResponse.FromEntity(CaseAction.Case),
    CaseAction.WorkflowCycleId,
    WorkflowCycleResponse.FromEntity(CaseAction.WorkflowCycle),
    CaseAction.StatusId);
}