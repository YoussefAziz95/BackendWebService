using Application.Profiles;
using Domain;

namespace Application.Features;
public record CategoryResponse(
string Name,
int? ParentId,
int? FileId,
FileLogResponse? File,
CategoryResponse? ParentCategory,
List<CategoryResponse> SubCategories) : IConvertibleFromEntity<Category, CategoryResponse>
{
    public static CategoryResponse FromEntity(Category Category) =>
    new CategoryResponse(
    Category.Name,
    Category.ParentId,
    Category.FileId,
    FileLogResponse.FromEntity(Category.File),
    CategoryResponse.FromEntity(Category.ParentCategory),
    Category.SubCategories.Select(CategoryResponse.FromEntity).ToList());
}
