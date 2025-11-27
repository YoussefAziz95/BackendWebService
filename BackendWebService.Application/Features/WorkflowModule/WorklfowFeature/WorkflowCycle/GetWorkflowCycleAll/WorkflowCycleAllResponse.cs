using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;
public record WorkflowCycleAllResponse(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
int? WorkflowReviewerId) : IConvertibleFromEntity<WorkflowCycle, WorkflowCycleAllResponse>, IRequest<int>
{
    public static WorkflowCycleAllResponse FromEntity(WorkflowCycle WorkflowCycle) =>
    new WorkflowCycleAllResponse(
    WorkflowCycle.ActionOrder,
    WorkflowCycle.ActionType,
    WorkflowCycle.Mandatory,
    WorkflowCycle.WorkflowId,
    WorkflowCycle.WorkflowReviewerId);
}


