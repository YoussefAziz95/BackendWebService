namespace Application.Features.Common;
public record GetPaginatedRequest(int? pageNumber = 0, int? pageSize = 100, string? filterBy = "", string? sortBy = "", bool sortDescending = false);
