using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateWorkflowCycleRequest(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
Workflow Workflow,
int? WorkflowReviewerId,
User? WorkflowReviewer);