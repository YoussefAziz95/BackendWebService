namespace Application.Features;

public record GetPaginatedWorkflowCase(int Id, int WorkflowId, int RequesterId, string Status);