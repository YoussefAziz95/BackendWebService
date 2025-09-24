using Application.Profiles;
using Domain;

namespace Application.Features;
public record OfferItemResponse(
int Quantity,
int? RequiredAmount,
int ServiceId,
int OfferId) : IConvertibleFromEntity<OfferItem, OfferItemResponse>
{
    public static OfferItemResponse FromEntity(OfferItem OfferItem) =>
    new OfferItemResponse(
    OfferItem.Quantity,
    OfferItem.RequiredAmount,
    OfferItem.ServiceId,
    OfferItem.OfferId);
}


