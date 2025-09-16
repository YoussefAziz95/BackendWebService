using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record WorkflowCycleAllResponse(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
int? WorkflowReviewerId): IConvertibleFromEntity<WorkflowCycle, WorkflowCycleAllResponse>        
{
public static WorkflowCycleAllResponse FromEntity(WorkflowCycle WorkflowCycle) =>
new WorkflowCycleAllResponse(
WorkflowCycle.ActionOrder,
WorkflowCycle.ActionType,
WorkflowCycle.Mandatory,
WorkflowCycle.WorkflowId,
WorkflowCycle.WorkflowReviewerId);
}


