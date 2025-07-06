using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateWorkflowCycleRequest(int? Id, int WorkflowId, int ActionOrder, bool? Mandatory, string ActorType, string ActionType, int ActorId, [property: Required] string ObjectType, [property: Required] int ObjectId);