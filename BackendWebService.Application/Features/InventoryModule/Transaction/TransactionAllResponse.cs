using Domain.Enums;

namespace Application.Features;
public record TransactionAllResponse(
int UserId,
PaymentEnum PaymentMethod,
TransactionEnum Type,
decimal Amount,
CurrencyEnum Currency,
StatusEnum Status,
string ReferenceNumber,
string? Notes,
DateTime TransactionDate,
DateTime? UpdatedAt);

