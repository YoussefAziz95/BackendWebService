using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DealRequest(
int OrganizationId,
int OfferId,
int? UserId,
int CompanyVendorId,
int? Vat,
int? Quantity,
int? Discount,
int? StatusId,
decimal? TotalPrice,
decimal? FinalPrice) : IRequest<DealResponse>
{
public IValidator<DealRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DealRequest> validator)
{
throw new NotImplementedException();
}
}

