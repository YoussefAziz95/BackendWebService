namespace Application.Features;
public record GetPaginatedWorkflowCycle(
WorkflowCycleAllResponse WorkflowCycleAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");