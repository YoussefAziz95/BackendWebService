using Domain;

namespace Application.Features;
public record CategoryResponse(
string Name,
int? ParentId,
int? FileId,
FileLog? File,
Category? ParentCategory,
List<CategoryResponse> SubCategories);