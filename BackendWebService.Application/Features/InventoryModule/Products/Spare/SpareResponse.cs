using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record SpareResponse(
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
ProductResponse Product):IConvertibleFromEntity<Spare, SpareResponse>
{
public static SpareResponse FromEntity(Spare Spare) =>
new SpareResponse(
Spare.IsAvailable,
Spare.RequiredAmount,
Spare.AvailableAmount,
Spare.ProductId,
ProductResponse.FromEntity(Spare.Product));
}