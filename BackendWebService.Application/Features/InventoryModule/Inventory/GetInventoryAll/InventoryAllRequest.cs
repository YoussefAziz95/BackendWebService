using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record InventoryAllRequest(
string Name,
int? CategoryId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<InventoryAllResponse>>
{
    public IValidator<InventoryAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<InventoryAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

