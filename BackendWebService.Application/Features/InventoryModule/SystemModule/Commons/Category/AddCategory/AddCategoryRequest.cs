using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddCategoryRequest(
string Name,
int? ParentId,
int? FileId,
AddFileLogRequest? File,
AddCategoryRequest ParentCategory,
List<AddCategoryRequest> SubCategories) : IConvertibleToEntity<Category>, IRequest<int>
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
