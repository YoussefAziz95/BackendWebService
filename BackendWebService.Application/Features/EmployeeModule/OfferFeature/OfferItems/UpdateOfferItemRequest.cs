using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateOfferItemRequest(
int Quantity,
int? RequiredAmount,
int ServiceId,
int OfferId) : IConvertibleToEntity<OfferItem>
{
public OfferItem ToEntity() => new OfferItem
{
Quantity = Quantity,
RequiredAmount = RequiredAmount,
ServiceId = ServiceId,
OfferId = OfferId

};
}

