using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record StorageUnitAllRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<StorageUnitAllResponse>>
{
    public IValidator<StorageUnitAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<StorageUnitAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

