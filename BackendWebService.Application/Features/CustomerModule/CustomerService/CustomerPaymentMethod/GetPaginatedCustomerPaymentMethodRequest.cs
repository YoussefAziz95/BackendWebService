namespace Application.Features;
public record GetPaginatedCustomerPaymentMethodRequest(
CustomerPaymentMethodAllResponse CustomerPaymentMethodAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

