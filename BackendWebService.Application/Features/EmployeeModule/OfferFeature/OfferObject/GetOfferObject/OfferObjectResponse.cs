using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record OfferObjectResponse(
int OfferId,
int ObjectId,
string ObjectType,
string? Notes) : IConvertibleFromEntity<OfferObject, OfferObjectResponse>, IRequest<int>
{
    public static OfferObjectResponse FromEntity(OfferObject OfferObject) =>
    new OfferObjectResponse(
    OfferObject.OfferId,
    OfferObject.ObjectId,
    OfferObject.Notes,
    OfferObject.ObjectType);
}

