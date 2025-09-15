using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record DealDetailsResponse(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
DealResponse Deal,
OfferItemResponse OfferItem) : IConvertibleFromEntity<DealDetails, DealDetailsResponse>
{
    public static DealDetailsResponse FromEntity(DealDetails DealDetails) =>
    new DealDetailsResponse(
    DealDetails.DealId,
    DealDetails.OfferItemId,
    DealDetails.Quantity,
    DealDetails.DetailPrice,
    DealDetails.ItemPrice,
    DealResponse.FromEntity(DealDetails.Deal),
    OfferItemResponse.FromEntity(DealDetails.OfferItem));
}
