using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features; 
public record StorageUnitRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit) : IRequest<StorageUnitResponse>
{
    public IValidator<StorageUnitRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<StorageUnitRequest> validator)
    {
        throw new NotImplementedException();
    }
}

