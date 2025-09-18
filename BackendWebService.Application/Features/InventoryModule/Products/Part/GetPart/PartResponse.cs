using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PartResponse(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
ProductResponse Product) : IConvertibleFromEntity<Part, PartResponse>
{
    public static PartResponse FromEntity(Part Part) =>
    new PartResponse(
    Part.Name,
    Part.Description,
    Part.Code,
    Part.Image,
    Part.PartNumber,
    Part.Manufacturer,
    Part.ProductId,
    ProductResponse.FromEntity(Part.Product));
}