namespace Application.Features;
public record GetPaginatedOrderItemRequest(
OrderItemAllResponse OrderItemAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

