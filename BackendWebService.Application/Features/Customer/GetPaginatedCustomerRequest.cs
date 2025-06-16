namespace Application.Features;

public record GetPaginatedCustomerRequest(
CustomerAllResponse CustomerAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

