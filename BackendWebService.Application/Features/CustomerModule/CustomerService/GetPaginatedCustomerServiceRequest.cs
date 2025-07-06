﻿namespace Application.Features;
public record GetPaginatedCustomerServiceRequest(
CustomerServiceAllResponse CustomerServiceAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

