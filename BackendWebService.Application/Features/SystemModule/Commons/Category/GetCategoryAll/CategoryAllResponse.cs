using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CategoryAllResponse(
string Name,
int? ParentId,
int? FileId) : IConvertibleFromEntity<Category, CategoryAllResponse>
{
    public static CategoryAllResponse FromEntity(Category Category) =>
    new CategoryAllResponse(
    Category.Name,
    Category.ParentId,
    Category.FileId);
}
