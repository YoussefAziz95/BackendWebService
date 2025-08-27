using Domain;

namespace Application.Features;
public record AddWorkflowCycleRequest(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
Workflow Workflow,
int? WorkflowReviewerId,
User? WorkflowReviewer);