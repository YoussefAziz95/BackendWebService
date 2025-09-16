using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record OfferItemAllResponse(
int Quantity,
int? RequiredAmount,
int ServiceId,
int OfferId) : IConvertibleFromEntity<OfferItem, OfferItemAllResponse>
{
    public static OfferItemAllResponse FromEntity(OfferItem OfferItem) =>
    new OfferItemAllResponse(
    OfferItem.Quantity,
    OfferItem.RequiredAmount,
    OfferItem.ServiceId,
    OfferItem.OfferId);
}

