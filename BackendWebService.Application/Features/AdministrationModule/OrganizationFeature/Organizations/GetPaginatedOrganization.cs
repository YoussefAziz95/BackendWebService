using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record GetPaginatedOrganization(
OrganizationAllResponse OrganizationAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");