using Application.Profiles;
using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record SupplierResponse(
int OrganizationId,
decimal? Rating,
string? BankAccount,
StatusEnum Status,
List<AddSupplierCategoryRequest> SupplierCategories): IConvertibleFromEntity<Supplier, SupplierAllResponse>        
{
public static SupplierAllResponse FromEntity(Supplier Supplier) =>
new SupplierAllResponse(
Supplier.OrganizationId,
Supplier.Rating,
Supplier.BankAccount,
Supplier.Status,
Supplier.SupplierCategories.Select(x => x.ToEntity()).ToList());
}