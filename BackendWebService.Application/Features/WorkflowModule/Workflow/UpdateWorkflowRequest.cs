using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateWorkflowRequest(
string? Name,
string? Description,
int UserId,
int CompanyId,
List<UpdateWorkflowCycleRequest> WorkflowCycles);