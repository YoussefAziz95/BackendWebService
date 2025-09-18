using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddPartRequest(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
AddProductRequest Product) : IConvertibleToEntity<Part>, IRequest<int>
{
    public Part ToEntity() => new Part
    {
        Name = Name,
        Description = Description,
        Code = Code,
        Image = Image,
        PartNumber = PartNumber,
        Manufacturer = Manufacturer,
        ProductId = ProductId,
        Product = Product.ToEntity()

    };
}