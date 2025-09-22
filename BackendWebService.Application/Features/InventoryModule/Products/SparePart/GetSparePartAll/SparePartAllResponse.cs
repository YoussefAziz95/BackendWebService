using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SparePartAllResponse(
int PartId,
int? SpareId) : IConvertibleFromEntity<SparePart, SparePartAllResponse>
{
    public static SparePartAllResponse FromEntity(SparePart SparePart) =>
    new SparePartAllResponse(
    SparePart.PartId,
    SparePart.SpareId);
}

