using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;
public record WorkflowCycleResponse(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
WorkflowResponse Workflow,
int? WorkflowReviewerId,
UserResponse? WorkflowReviewer) : IConvertibleFromEntity<WorkflowCycle, WorkflowCycleResponse>, IRequest<int>
{
    public static WorkflowCycleResponse FromEntity(WorkflowCycle WorkflowCycle) =>
    new WorkflowCycleResponse(
    WorkflowCycle.ActionOrder,
    WorkflowCycle.ActionType,
    WorkflowCycle.Mandatory,
    WorkflowCycle.WorkflowId,
    WorkflowResponse.FromEntity(WorkflowCycle.Workflow),
    WorkflowCycle.WorkflowReviewerId,
    UserResponse.FromEntity(WorkflowCycle.WorkflowReviewer));
}