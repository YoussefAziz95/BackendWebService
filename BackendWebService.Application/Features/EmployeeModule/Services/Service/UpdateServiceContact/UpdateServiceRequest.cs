using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateServiceRequest(
string Name,
string Description,
string Code,
int CategoryId,
UpdateCategoryRequest Category) : IConvertibleToEntity<Service>,IRequest<int>
{
    public Service ToEntity() => new Service
    {
        Name = Name,
        Description = Description,
        Code = Code,
        CategoryId = CategoryId,
        Category = Category.ToEntity()


    };
}
