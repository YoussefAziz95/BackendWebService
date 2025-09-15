using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DealAllRequest(
int OrganizationId,
int OfferId,
int? UserId,
int CompanyVendorId,
int? Vat,
int? Quantity,
int? Discount,
int? StatusId,
decimal? TotalPrice,
decimal? FinalPrice,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<DealAllResponse>>
{
    public IValidator<DealAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DealAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

