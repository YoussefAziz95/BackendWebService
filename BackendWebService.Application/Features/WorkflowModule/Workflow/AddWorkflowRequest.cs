using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddWorkflowRequest(
string? Name,
string? Description,
int UserId,
int CompanyId, 
List<AddWorkflowCycleRequest> WorkflowCycles);