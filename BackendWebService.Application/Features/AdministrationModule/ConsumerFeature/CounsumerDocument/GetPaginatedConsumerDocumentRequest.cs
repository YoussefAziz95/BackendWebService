namespace Application.Features;
public record GetPaginatedConsumerDocumentRequest(
ConsumerDocumentAllResponse ConsumerDocumentAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

