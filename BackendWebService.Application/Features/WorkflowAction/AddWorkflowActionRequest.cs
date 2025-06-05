namespace Application.Features;

public record AddWorkflowActionRequest(int WorkflowCaseId, int AssignedOn, int ActionOrder, string ActionType);