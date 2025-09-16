using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OfferObjectRequest(
int OfferId,
int ObjectId,
string Notes,
string ObjectType) : IRequest<OfferObjectResponse>
{
public IValidator<OfferObjectRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OfferObjectRequest> validator)
{
throw new NotImplementedException();
}
}

