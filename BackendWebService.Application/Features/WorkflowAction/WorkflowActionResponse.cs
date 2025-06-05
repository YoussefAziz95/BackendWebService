namespace Application.Features;

public record WorkflowActionResponse(int Id, int WorkflowCaseId, int AssignedOn, DateTime AssignedAt, DateTime? ActionAt, string Status, string? Comment, int? DelegateId, bool IsActive, DateTime CreatedDate, DateTime? UpdateDate);