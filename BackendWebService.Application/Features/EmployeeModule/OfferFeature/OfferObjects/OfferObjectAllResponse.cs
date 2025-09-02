using Application.Profiles;
using Domain;

namespace Application.Features;
public record OfferObjectAllResponse(
int OfferId,
int ObjectId,
string Notes,
string ObjectType) : IConvertibleFromEntity<OfferObject, OfferObjectAllResponse>
{
public static OfferObjectAllResponse FromEntity(OfferObject OfferObject) =>
new OfferObjectAllResponse(
OfferObject.OfferId,
OfferObject.ObjectId,
OfferObject.Notes,
OfferObject.ObjectType);
}

