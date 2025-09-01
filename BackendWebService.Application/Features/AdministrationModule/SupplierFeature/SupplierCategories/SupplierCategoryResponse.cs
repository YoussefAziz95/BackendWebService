using Application.Profiles;

namespace Application.Features;
public record SupplierCategoryResponse(
int SupplierId,
int CategoryId) : IConvertibleFromEntity<SupplierCategory, SupplierCategoryResponse>
{
public static SupplierCategoryResponse FromEntity(SupplierCategory SupplierCategory) =>
new SupplierCategoryResponse(
SupplierCategory.SupplierId,
SupplierCategory.CategoryId);
}
