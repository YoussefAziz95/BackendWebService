using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateWorkflowCycleRequest(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
UpdateWorkflowRequest Workflow,
int? WorkflowReviewerId,
UpdateUserRequest? WorkflowReviewer) : IConvertibleToEntity<WorkflowCycle>
{
public WorkflowCycle ToEntity() => new WorkflowCycle
{
ActionOrder = ActionOrder,
ActionType = ActionType,
Mandatory = Mandatory,
WorkflowId = WorkflowId,
Workflow = Workflow.ToEntity(),
WorkflowReviewerId = WorkflowReviewerId,
WorkflowReviewer = WorkflowReviewer.ToEntity()
};
}