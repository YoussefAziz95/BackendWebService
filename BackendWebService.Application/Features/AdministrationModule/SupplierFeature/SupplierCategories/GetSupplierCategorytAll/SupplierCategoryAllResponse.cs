using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record SupplierCategoryAllResponse(
int SupplierId,
int CategoryId) : IConvertibleFromEntity<SupplierCategory, SupplierCategoryAllResponse>
{
    public static SupplierCategoryAllResponse FromEntity(SupplierCategory SupplierCategory) =>
    new SupplierCategoryAllResponse(
    SupplierCategory.SupplierId,
    SupplierCategory.CategoryId);
}
