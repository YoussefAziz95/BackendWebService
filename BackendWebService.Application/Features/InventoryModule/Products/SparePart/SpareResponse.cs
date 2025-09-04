using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record SparePartResponse(
int PartId,
int? SpareId,
PartResponse Part,
SpareResponse? Spare) : IConvertibleFromEntity<SparePart, SparePartResponse>
{
public static SparePartResponse FromEntity(SparePart SparePart) =>
new SparePartResponse(
SparePart.PartId,
SparePart.SpareId,
SparePart.Part.ToEntity,
SparePart.Spare.ToEntity());
}
