using Application.Profiles;
using Domain;

namespace Application.Features;

public record UpdateDealDetailsRequest(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
Deal Deal,
OfferItem OfferItem):IConvertibleToEntity<DealDetails>
{
public DealDetails ToEntity() => new DealDetails
{
DealId = DealId,
OfferItemId = OfferItemId,
Quantity = Quantity,
DetailPrice = DetailPrice,
ItemPrice = ItemPrice,
Deal = Deal,
OfferItem = OfferItem
};
}