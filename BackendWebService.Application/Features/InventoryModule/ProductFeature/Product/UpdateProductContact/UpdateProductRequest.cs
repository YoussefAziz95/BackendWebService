using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateProductRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
UpdateCategoryRequest Category,
UpdateFileLogRequest? File) : IConvertibleToEntity<Product>, IRequest<int>
{
    public Product ToEntity() => new Product
    {
        Number = Number,
        Name = Name,
        Description = Description,
        Code = Code,
        PartNumber = PartNumber,
        Manufacturer = Manufacturer,
        FileId = FileId,
        Category = Category.ToEntity(),
        File = File.ToEntity()
    };
}