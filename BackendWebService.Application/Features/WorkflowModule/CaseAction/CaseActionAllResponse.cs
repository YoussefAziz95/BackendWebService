using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CaseActionAllResponse(
int? Order,
int? WorkflowActorId,
int CaseId,
int WorkflowCycleId,
int StatusId) : IConvertibleFromEntity<CaseAction, CaseActionAllResponse>
{
    public static CaseActionAllResponse FromEntity(CaseAction CaseAction) =>
    new CaseActionAllResponse(
    CaseAction.Order,
    CaseAction.WorkflowActorId,
    CaseAction.CaseId,
    CaseAction.WorkflowCycleId,
    CaseAction.StatusId);
}

