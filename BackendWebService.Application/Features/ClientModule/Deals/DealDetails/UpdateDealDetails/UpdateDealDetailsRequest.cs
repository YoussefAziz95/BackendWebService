using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateDealDetailsRequest(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
UpdateDealRequest Deal,
UpdateOfferItemRequest OfferItem) : IConvertibleToEntity<DealDetails>,IRequest<int>
{
    public DealDetails ToEntity() => new DealDetails
    {
        DealId = DealId,
        OfferItemId = OfferItemId,
        Quantity = Quantity,
        DetailPrice = DetailPrice,
        ItemPrice = ItemPrice,
        Deal = Deal.ToEntity(),
        OfferItem = OfferItem.ToEntity()
    };
}