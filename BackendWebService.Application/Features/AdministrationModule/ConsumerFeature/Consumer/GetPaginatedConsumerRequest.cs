namespace Application.Features;
public record GetPaginatedConsumerRequest(
ConsumerAllResponse ConsumerAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

