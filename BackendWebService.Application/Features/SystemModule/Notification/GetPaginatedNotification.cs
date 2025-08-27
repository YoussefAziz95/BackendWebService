namespace Application.Features;
public record GetPaginatedNotification(
 NotificationAllResponse NotificationAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");