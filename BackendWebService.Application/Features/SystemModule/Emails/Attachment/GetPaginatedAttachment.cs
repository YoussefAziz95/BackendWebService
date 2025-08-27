namespace Application.Features;
public record GetPaginatedAttachment(
 AttachmentAllResponse AttachmentAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");