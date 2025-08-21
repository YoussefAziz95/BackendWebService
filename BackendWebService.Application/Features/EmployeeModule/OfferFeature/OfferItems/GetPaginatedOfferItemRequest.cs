namespace Application.Features;
public record GetPaginatedOfferItemRequest(
OfferItemAllResponse OfferItemAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

