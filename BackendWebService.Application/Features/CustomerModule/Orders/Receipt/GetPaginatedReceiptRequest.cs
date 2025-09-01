namespace Application.Features;
public record GetPaginatedReceiptRequest(
ReceiptAllResponse ReceiptAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

