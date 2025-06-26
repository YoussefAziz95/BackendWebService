namespace Application.Features;

public record AddCaseActionRequest(int CaseId, int AssignedOn, int ActionOrder, string ActionType);