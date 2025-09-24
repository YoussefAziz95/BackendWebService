using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features; 
public record TransactionAllRequest(
int UserId,
PaymentEnum PaymentMethod,
TransactionEnum Type,
decimal Amount,
CurrencyEnum Currency,
StatusEnum Status,
string ReferenceNumber,
string? Notes,
DateTime TransactionDate,
DateTime? UpdatedAt,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<TransactionAllResponse>>
{
    public IValidator<TransactionAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TransactionAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

