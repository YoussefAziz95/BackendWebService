using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddProductRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
AddCategoryRequest Category,
AddFileLogRequest? File) : IConvertibleToEntity<Product>, IRequest<int>
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