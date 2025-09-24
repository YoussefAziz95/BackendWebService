using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateCategoryRequest(
string Name,
int? ParentId,
int? FileId,
UpdateFileLogRequest? File,
UpdateCategoryRequest? ParentCategory,
List<UpdateCategoryRequest> SubCategories) : IConvertibleToEntity<Category>, IRequest<int>
{
    public Category ToEntity() => new Category
    {
        Name = Name,
        ParentId = ParentId,
        FileId = FileId,
        File = File.ToEntity(),
        ParentCategory = ParentCategory.ToEntity(),
        SubCategories = SubCategories.Select(x => x.ToEntity()).ToList()
    };
}
