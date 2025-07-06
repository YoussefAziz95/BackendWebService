namespace Application.Features;
public record UpdateCategoryRequest(
int Id,
string Name,
int? ParentId,
int FileId);
