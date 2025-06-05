namespace Application.Features;

public record GetPaginatedWorkflowCycle(int Id, int WorkflowId, int ActionOrder, bool? Mandatory, string ActorType, string ActionType, int ActorId, string ObjectType, int ObjectId);