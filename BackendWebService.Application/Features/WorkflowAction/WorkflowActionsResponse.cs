namespace Application.Features;

public record WorkflowActionsResponse(int Id, int CaseId, string OrganizationName, string RequesterName, string AssignedOnType, string AssignedOnName, string CaseName, string? CaseType, string? ActionType, string? ActionName);