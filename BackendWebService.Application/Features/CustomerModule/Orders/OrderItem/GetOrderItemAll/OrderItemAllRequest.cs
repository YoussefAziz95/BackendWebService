using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OrderItemAllRequest(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<OrderItemAllResponse>>
{
    public IValidator<OrderItemAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OrderItemAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

