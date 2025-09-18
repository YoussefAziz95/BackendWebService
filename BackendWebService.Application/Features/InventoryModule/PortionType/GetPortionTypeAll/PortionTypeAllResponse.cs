using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PortionTypeAllResponse(
string Name,
string? Description,
string? UnitOfMeasure) : IConvertibleFromEntity<PortionType, PortionTypeAllResponse>
{
    public static PortionTypeAllResponse FromEntity(PortionType PortionType) =>
    new PortionTypeAllResponse(
    PortionType.Name,
    PortionType.Description,
    PortionType.UnitOfMeasure);
}

