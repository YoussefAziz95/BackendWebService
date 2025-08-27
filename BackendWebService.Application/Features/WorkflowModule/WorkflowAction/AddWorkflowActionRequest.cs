namespace Application.Features;
public record AddWorkflowActionRequest(int CaseId, int AssignedOn, int ActionOrder, string ActionType);