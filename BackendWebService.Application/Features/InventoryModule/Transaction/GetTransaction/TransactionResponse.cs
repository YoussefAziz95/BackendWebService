using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record TransactionResponse(
int UserId,
PaymentEnum PaymentMethod,
TransactionEnum Type,
decimal Amount,
CurrencyEnum Currency,
StatusEnum Status,
string ReferenceNumber,
string? Notes,
DateTime TransactionDate,
DateTime? UpdatedAt) : IConvertibleFromEntity<Transaction, TransactionResponse>
{
    public static TransactionResponse FromEntity(Transaction Transaction) =>
    new TransactionResponse(
    Transaction.UserId,
    Transaction.PaymentMethod,
    Transaction.Type,
    Transaction.Amount,
    Transaction.Currency,
    Transaction.Status,
    Transaction.ReferenceNumber,
    Transaction.Notes,
    Transaction.TransactionDate,
    Transaction.UpdatedAt);
}