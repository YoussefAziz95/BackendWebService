using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OrderRequest(
int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName) : IRequest<OrderResponse>
{
public IValidator<OrderRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OrderRequest> validator)
{
throw new NotImplementedException();
}
}

