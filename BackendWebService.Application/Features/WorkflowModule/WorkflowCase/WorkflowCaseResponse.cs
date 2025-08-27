namespace Application.Features;
public record WorkflowCaseResponse(int Id, int WorkflowId, int RequesterId, string Status, bool IsActive, DateTime CreatedDate, DateTime? UpdateDate);