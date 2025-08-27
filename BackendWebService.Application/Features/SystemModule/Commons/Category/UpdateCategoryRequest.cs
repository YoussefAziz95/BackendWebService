using Domain;

namespace Application.Features;
public record UpdateCategoryRequest(
string Name,
int? ParentId,
int? FileId,
FileLog? File,
Category? ParentCategory,
List<UpdateCategoryRequest> SubCategories);
