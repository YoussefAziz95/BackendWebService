using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddWorkflowCycleRequest(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
AddWorkflowRequest Workflow,
int? WorkflowReviewerId,
AddUserRequest? WorkflowReviewer):IConvertibleToEntity<WorkflowCycle>
{
public WorkflowCycle ToEntity() => new WorkflowCycle
{
ActionOrder = ActionOrder,
ActionType = ActionType,
Mandatory = Mandatory,
WorkflowId = WorkflowId,
Workflow = Workflow.ToEntity(),
WorkflowReviewerId = WorkflowReviewerId,
WorkflowReviewer= WorkflowReviewer.ToEntity()
};
}