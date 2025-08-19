namespace Application.Features;
public record GetPaginatedAddressRequest(
AddressAllResponse AddressAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

