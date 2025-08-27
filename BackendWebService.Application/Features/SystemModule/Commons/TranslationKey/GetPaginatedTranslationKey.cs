namespace Application.Features;
public record GetPaginatedTranslationKey(
 TranslationKeyAllResponse TranslationKeyAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");