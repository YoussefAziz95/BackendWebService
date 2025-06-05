namespace Application.Features;

public record AddWorkflowCycleRequest(int WorkflowId, int ActionOrder, bool? Mandatory, string ActorType, string ActionType, int ActorId, int ObjectId, string ObjectType);