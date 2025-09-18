using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdatePortionTypeRequest(
string Name,
string? Description,
string? UnitOfMeasure,
List<UpdatePortionRequest> Portions) : IConvertibleToEntity<PortionType>, IRequest<int>
{
    public PortionType ToEntity() => new PortionType
    {
        Name = Name,
        Description = Description,
        UnitOfMeasure = UnitOfMeasure,
        Portions = Portions.Select(x => x.ToEntity()).ToList()
    };
}