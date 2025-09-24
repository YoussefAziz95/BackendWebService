using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierResponse(
int OrganizationId,
decimal? Rating,
string? BankAccount,
StatusEnum Status,
List<SupplierCategoryResponse> SupplierCategories) : IConvertibleFromEntity<Supplier, SupplierResponse>
{
    public static SupplierResponse FromEntity(Supplier Supplier) =>
    new SupplierResponse(
    Supplier.OrganizationId,
    Supplier.Rating,
    Supplier.BankAccount,
    Supplier.Status,
    Supplier.SupplierCategories.Select(SupplierCategoryResponse.FromEntity).ToList());
}