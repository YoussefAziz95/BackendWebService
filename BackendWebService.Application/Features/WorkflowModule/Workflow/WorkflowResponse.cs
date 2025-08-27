using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowResponse(
string? Name,
string? Description,
int UserId,
int CompanyId,
List<WorkflowCycleResponse> WorkflowCycles);