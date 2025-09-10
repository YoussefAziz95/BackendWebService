using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddSupplierCategoryRequest(
int SupplierId,
int CategoryId,
AddCategoryRequest Category,
AddSupplierRequest Supplier) : IConvertibleToEntity<SupplierCategory>,IRequest<int>
{
    public SupplierCategory ToEntity() => new SupplierCategory
    {
        SupplierId = SupplierId,
        CategoryId = CategoryId,
        Category= Category.ToEntity(),
        Supplier= Supplier.ToEntity()
    };
}
