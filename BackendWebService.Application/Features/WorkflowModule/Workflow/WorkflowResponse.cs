using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowResponse([property: Required] int? Id, [property: Required] string Name, [property: Required] string Description, [property: Required] int? UserId, [property: Required] int? CompanyId, [property: Required] string ObjectType, [property: Required] int ObjectId, List<WorkflowCycleResponse> WorkflowCycles);