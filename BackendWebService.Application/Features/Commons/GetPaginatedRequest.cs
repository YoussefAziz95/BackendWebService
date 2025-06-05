namespace Application.Features.Common;
public record GetPaginatedRequest(int? pageNumber, int? pageSize, string? filterBy, string? sortBy, bool sortDescending, int? CompanyId);
