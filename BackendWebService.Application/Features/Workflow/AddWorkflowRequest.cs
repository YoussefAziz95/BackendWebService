using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record AddWorkflowRequest(int Id, string? Name, string? Description, int UserId, int CompanyId, [property: Required] string ObjectType, [property: Required] int ObjectId, List<AddWorkflowCycleRequest> WorkflowCycles);