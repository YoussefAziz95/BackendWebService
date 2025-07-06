namespace Application.Features;
public record CaseResponse(int Id, int WorkflowId, int RequesterId, string Status, bool IsActive, DateTime CreatedDate, DateTime? UpdateDate);