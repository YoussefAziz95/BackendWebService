using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateSparePartRequest(
int PartId,
int? SpareId,
UpdatePartRequest Part,
UpdateSpareRequest? Spare) : IConvertibleToEntity<SparePart>, IRequest<int>
{
    public SparePart ToEntity() => new SparePart
    {
        PartId = PartId,
        SpareId = SpareId,
        Part = Part.ToEntity(),
        Spare = Spare.ToEntity()

    };
}