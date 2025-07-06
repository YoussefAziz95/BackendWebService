namespace Application.Features;
public record GetPaginatedCase(int Id, int WorkflowId, int RequesterId, string Status);