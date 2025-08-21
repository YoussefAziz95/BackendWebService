namespace Application.Features;
public record GetPaginatedConsumerAccountRequest(
ConsumerAccountAllResponse ConsumerAccountAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

