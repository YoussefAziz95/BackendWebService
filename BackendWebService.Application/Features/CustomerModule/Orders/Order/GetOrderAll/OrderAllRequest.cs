using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OrderAllRequest(
int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<OrderAllResponse>>
{
    public IValidator<OrderAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OrderAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

