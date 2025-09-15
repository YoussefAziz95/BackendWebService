using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record DealDetailsAllResponse(
int DealId,
int OfferItemId,
int Quantity,
decimal? DetailPrice,
decimal? ItemPrice) : IConvertibleFromEntity<DealDetails, DealDetailsAllResponse>
{
    public static DealDetailsAllResponse FromEntity(DealDetails DealDetails) =>
    new DealDetailsAllResponse(
    DealDetails.DealId,
    DealDetails.OfferItemId,
    DealDetails.Quantity,
    DealDetails.DetailPrice,
    DealDetails.ItemPrice);
}
