using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowCycleResponse(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
WorkflowResponse Workflow,
int? WorkflowReviewerId,
UserResponse? WorkflowReviewer): IConvertibleFromEntity<WorkflowCycle, WorkflowCycleResponse>
{
public static WorkflowCycleResponse FromEntity(WorkflowCycle WorkflowCycle) =>
new WorkflowCycleResponse(
WorkflowCycle.ActionOrder,
WorkflowCycle.ActionType,
WorkflowCycle.Mandatory,
WorkflowCycle.WorkflowId,
WorkflowCycle.Workflow.ToEntity(),
WorkflowCycle.WorkflowReviewerId,
WorkflowCycle.WorkflowReviewer.ToEntity());
}