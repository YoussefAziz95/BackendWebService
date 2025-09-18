using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddStorageUnitRequest(
int InventoryId,
int? PortionTypeId,
int FullQuantity,
UnitEnum Unit) : IConvertibleToEntity<StorageUnit>, IRequest<int>
{
    public StorageUnit ToEntity() => new StorageUnit
    {
        InventoryId = InventoryId,
        PortionTypeId = PortionTypeId,
        FullQuantity = FullQuantity,
        Unit = Unit,
    };
}