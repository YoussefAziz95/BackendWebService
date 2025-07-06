using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowCycleResponse([property: Required] int Id, [property: Required] int WorkflowId, [property: Required] int ActionOrder, [property: Required] bool? Mandatory, [property: Required] string ActorType, [property: Required] string ActionType, [property: Required] int ActorId, [property: Required] string ObjectType, [property: Required] int ObjectId);