using Application.Profiles;
using Domain;

namespace Application.Features;
public record PartAllResponse(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId) : IConvertibleFromEntity<Part, PartAllResponse>
{
    public static PartAllResponse FromEntity(Part Part) =>
    new PartAllResponse(
    Part.Name,
    Part.Description,
    Part.Code,
    Part.Image,
    Part.PartNumber,
    Part.Manufacturer,
    Part.ProductId);
}

