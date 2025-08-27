namespace Application.Features;
public record GetPaginatedWorkflow(
 WorkflowAllResponse WorkflowAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");