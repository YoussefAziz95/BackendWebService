namespace Application.Features;
public record GetPaginatedPortionItem(
 PortionItemAllResponse PortionItemAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");