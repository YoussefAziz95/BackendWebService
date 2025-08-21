namespace Application.Features;
public record GetPaginatedLDAPConfigRequest(
LDAPConfigAllResponse LDAPConfigAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

