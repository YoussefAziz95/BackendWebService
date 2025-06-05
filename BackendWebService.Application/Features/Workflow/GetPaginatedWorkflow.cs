namespace Application.Features;

public record GetPaginatedWorkflow(int Id, string Name, string Description, string? WorkflowType, string? ObjectType);