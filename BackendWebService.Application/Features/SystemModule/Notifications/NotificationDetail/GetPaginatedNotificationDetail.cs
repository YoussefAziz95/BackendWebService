namespace Application.Features;
public record GetPaginatedNotificationDetail(
 NotificationDetailAllResponse NotificationDetailAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");