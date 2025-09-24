using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DealDetailsAllRequest(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<DealDetailsAllResponse>>
{
    public IValidator<DealDetailsAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DealDetailsAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

