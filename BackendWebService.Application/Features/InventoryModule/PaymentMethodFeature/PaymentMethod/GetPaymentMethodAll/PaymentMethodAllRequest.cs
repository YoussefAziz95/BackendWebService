using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PaymentMethodAllRequest(
int UserId,
string MethodType,
string Provider,
string AccountNumber,
string Name,
PaymentEnum Type,
bool IsDefault,
bool IsVerified,
DateTime? ExpiryDate,
DateTime CreatedAt,
DateTime? UpdatedAt,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PaymentMethodAllResponse>>
{
    public IValidator<PaymentMethodAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PaymentMethodAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

