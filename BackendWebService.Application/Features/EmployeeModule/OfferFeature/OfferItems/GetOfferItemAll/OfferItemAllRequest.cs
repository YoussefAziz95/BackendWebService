using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OfferItemAllRequest(
int Quantity,
int? RequiredAmount,
int ServiceId,
int OfferId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<OfferItemAllResponse>>
{
    public IValidator<OfferItemAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OfferItemAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

