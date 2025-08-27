namespace Application.Features;
public record GetPaginatedPreDocument(
PreDocumentAllResponse PreDocumentAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");