using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateOfferObjectRequest(
int OfferId,
int ObjectId,
string ObjectType,
string? Notes) : IConvertibleToEntity<OfferObject>, IRequest<int>
{
    public OfferObject ToEntity() => new OfferObject
    {
        OfferId = OfferId,
        ObjectId = ObjectId,
        ObjectType = ObjectType,
        Notes = Notes

    };
}

