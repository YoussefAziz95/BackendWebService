using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OrderItemRequest(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime) : IRequest<OrderItemResponse>
{
public IValidator<OrderItemRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OrderItemRequest> validator)
{
throw new NotImplementedException();
}
}

