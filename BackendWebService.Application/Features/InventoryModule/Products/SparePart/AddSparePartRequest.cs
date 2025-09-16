using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddSparePartRequest(
int PartId,
int? SpareId,
AddPartRequest Part,
AddSpareRequest? Spare):IConvertibleToEntity<SparePart>
{
public SparePart ToEntity() => new SparePart
{
PartId = PartId,
SpareId = SpareId,
Part= Part.ToEntity(),
Spare = Spare.ToEntity()

};
}