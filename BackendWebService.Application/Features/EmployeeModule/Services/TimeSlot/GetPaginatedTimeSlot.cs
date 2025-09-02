namespace Application.Features;
public record GetPaginatedTimeSlot(
TimeSlotAllResponse TimeSlotAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");