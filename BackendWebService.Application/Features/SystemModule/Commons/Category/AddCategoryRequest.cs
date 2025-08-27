using Domain;

namespace Application.Features;
public record AddCategoryRequest(
string Name,
int? ParentId,
int? FileId,
FileLog? File,
Category? ParentCategory,
List<AddCategoryRequest> SubCategories);
