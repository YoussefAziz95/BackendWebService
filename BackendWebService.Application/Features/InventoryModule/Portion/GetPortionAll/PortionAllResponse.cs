using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PortionAllResponse(
int Quantity,
int StorageUnitId,
int PortionTypeId,
SizeEnum Size) : IConvertibleFromEntity<Portion, PortionAllResponse>
{
    public static PortionAllResponse FromEntity(Portion Portion) =>
    new PortionAllResponse(
    Portion.Quantity,
    Portion.StorageUnitId,
    Portion.PortionTypeId,
    Portion.Size);
}

