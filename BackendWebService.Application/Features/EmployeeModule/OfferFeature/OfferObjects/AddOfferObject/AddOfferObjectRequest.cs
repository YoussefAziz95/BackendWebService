using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddOfferObjectRequest(
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
