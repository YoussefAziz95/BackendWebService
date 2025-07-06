using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateWorkflowRequest(int Id, string? Name, string? Description, int UserId, int CompanyId, [property: Required] string ObjectType, [property: Required] int ObjectId, List<UpdateWorkflowCycleRequest> WorkflowCycles);