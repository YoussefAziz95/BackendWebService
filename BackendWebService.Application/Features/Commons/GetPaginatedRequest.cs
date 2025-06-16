﻿namespace Application.Features.Common;
public record GetPaginatedRequest(
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");
