using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddSupplierCategoryRequest(
int SupplierId,
int CategoryId):IConvertibleToEntity<SupplierCategory>
{
public SupplierCategory ToEntity() => new SupplierCategory
{
SupplierId = SupplierId,
CategoryId = CategoryId
};
}