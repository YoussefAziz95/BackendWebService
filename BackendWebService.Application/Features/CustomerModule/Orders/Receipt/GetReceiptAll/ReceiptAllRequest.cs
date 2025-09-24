using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ReceiptAllRequest(
int PaymentMethodId,
DateTime IssuedAt,
decimal TotalPaid,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ReceiptAllResponse>>
{
    public IValidator<ReceiptAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ReceiptAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

