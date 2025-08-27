namespace Application.Features;
public record GetPaginatedTransaction(
 TransactionAllResponse TransactionAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");