using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddCategoryRequest(
string Name,
int? ParentId,
int? FileId,
AddFileLogRequest? File,
AddCategoryRequest ParentCategory,
List<AddCategoryRequest> SubCategories):IConvertibleToEntity<Category>
{
public Category ToEntity() => new Category
{
Name = Name,
ParentId = ParentId,
FileId = FileId,
File = File.ToEntity(),
ParentCategory = ParentCategory.ToEntity(),
SubCategories = SubCategories.ToEntity()
};
}
