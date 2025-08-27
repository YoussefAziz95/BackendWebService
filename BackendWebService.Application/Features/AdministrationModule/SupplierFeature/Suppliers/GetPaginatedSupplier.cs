using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record GetPaginatedSupplier(
 SupplierAllResponse SupplierAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");