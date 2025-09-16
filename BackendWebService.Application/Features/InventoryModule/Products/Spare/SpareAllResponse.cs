using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SpareAllResponse(
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId): IConvertibleFromEntity<Spare, SpareAllResponse>        
{
public static SpareAllResponse FromEntity(Spare Spare) =>
new SpareAllResponse(
Spare.IsAvailable,
Spare.RequiredAmount,
Spare.AvailableAmount,
Spare.ProductId);
}

