using Application.Contracts.Features;
using Application.Profiles;
namespace Application.Features;
public record UpdateSupplierCategoryRequest(
int SupplierId,
int CategoryId,
UpdateCategoryRequest Category,
UpdateSupplierRequest Supplier) : IConvertibleToEntity<SupplierCategory>, IRequest<int>
{
    public SupplierCategory ToEntity() => new SupplierCategory
    {
        SupplierId = SupplierId,
        CategoryId = CategoryId,
        Category = Category.ToEntity(),
        Supplier = Supplier.ToEntity()
    };
}
