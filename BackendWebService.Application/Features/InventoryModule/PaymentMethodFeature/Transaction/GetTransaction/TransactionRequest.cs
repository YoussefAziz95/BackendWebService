using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record TransactionRequest(
int UserId,
PaymentEnum PaymentMethod,
TransactionEnum Type,
decimal Amount,
CurrencyEnum Currency,
StatusEnum Status,
string ReferenceNumber,
string? Notes,
DateTime TransactionDate,
DateTime? UpdatedAt) : IRequest<TransactionResponse>
{
    public IValidator<TransactionRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TransactionRequest> validator)
    {
        throw new NotImplementedException();
    }
}

