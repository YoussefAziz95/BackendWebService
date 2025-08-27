using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record GetPaginatedDealDetails(
DealDetailsAllResponse DealDetailsAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");