using Domain;
using Domain.Enums;

namespace Application.Features;
public record WorkflowCycleAllResponse(
int ActionOrder,
string? ActionType,
bool Mandatory,
int WorkflowId,
Workflow Workflow,
int? WorkflowReviewerId,
User? WorkflowReviewer);

