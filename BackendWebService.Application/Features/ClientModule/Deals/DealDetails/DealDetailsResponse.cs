using Application.Profiles;
using Domain;

namespace Application.Features;

public record DealDetailsResponse(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
Deal Deal,
OfferItem OfferItem):IConvertibleFromEntity<DealDetails, DealDetailsResponse>        
{
public static DealDetailsResponse FromEntity(DealDetails DealDetails) =>
new DealDetailsResponse(
DealDetails.DealId,
DealDetails.OfferItemId,
DealDetails.Quantity,
DealDetails.DetailPrice,
DealDetails.Deal,
DealDetails.ItemPrice,
DealDetails.OfferItem);
}
