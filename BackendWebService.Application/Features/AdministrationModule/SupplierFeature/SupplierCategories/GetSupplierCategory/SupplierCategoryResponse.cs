using Application.Profiles;

namespace Application.Features;
public record SupplierCategoryResponse(
int SupplierId,
int CategoryId,
 CategoryResponse Category,
 SupplierResponse Supplier) : IConvertibleFromEntity<SupplierCategory, SupplierCategoryResponse>
{
    public static SupplierCategoryResponse FromEntity(SupplierCategory SupplierCategory) =>
    new SupplierCategoryResponse(
    SupplierCategory.SupplierId,
    SupplierCategory.CategoryId,
     CategoryResponse.FromEntity(SupplierCategory.Category),
    SupplierResponse.FromEntity(SupplierCategory.Supplier));

}
