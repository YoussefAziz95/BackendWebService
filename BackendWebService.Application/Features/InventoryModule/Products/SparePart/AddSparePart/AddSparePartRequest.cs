using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddSparePartRequest(
int PartId,
int? SpareId,
AddPartRequest Part,
AddSpareRequest? Spare) : IConvertibleToEntity<SparePart>, IRequest<int>
{
    public SparePart ToEntity() => new SparePart
    {
        PartId = PartId,
        SpareId = SpareId,
        Part = Part.ToEntity(),
        Spare = Spare.ToEntity()

    };
}