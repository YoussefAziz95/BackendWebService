using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateTransactionRequest(
int UserId,
PaymentEnum PaymentMethod,
TransactionEnum Type,
decimal Amount,
CurrencyEnum Currency,
StatusEnum Status,
string ReferenceNumber,
string? Notes,
DateTime TransactionDate,
DateTime? UpdatedAt) : IConvertibleToEntity<Transaction>, IRequest<int>
{
    public Transaction ToEntity() => new Transaction
    {
        UserId = UserId,
        PaymentMethod = PaymentMethod,
        Type = Type,
        Amount = Amount,
        Currency = Currency,
        Status = Status,
        ReferenceNumber = ReferenceNumber,
        Notes = Notes,
        TransactionDate = TransactionDate,
        UpdatedAt = UpdatedAt
    };
}