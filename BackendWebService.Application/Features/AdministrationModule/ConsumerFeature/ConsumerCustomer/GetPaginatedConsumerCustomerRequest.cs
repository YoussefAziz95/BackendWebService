namespace Application.Features;
public record GetPaginatedConsumerCustomerRequest(
ConsumerCustomerAllResponse ConsumerCustomerAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

