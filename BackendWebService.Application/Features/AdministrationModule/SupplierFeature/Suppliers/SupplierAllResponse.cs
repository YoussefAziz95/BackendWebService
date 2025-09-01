using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierAllResponse(
 int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status): IConvertibleFromEntity<Supplier, SupplierAllResponse>        
{
public static SupplierAllResponse FromEntity(Supplier Supplier) =>
new SupplierAllResponse(
Supplier.OrganizationId,
Supplier.Rating,
Supplier.BankAccount,
Supplier.Status);
}
