using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierAccountAllResponse(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate): IConvertibleFromEntity<SupplierAccount, SupplierAccountAllResponse>        
{
public static SupplierAccountAllResponse FromEntity(SupplierAccount SupplierAccount) =>
new SupplierAccountAllResponse(
SupplierAccount.CompanyId,
SupplierAccount.SupplierId,
SupplierAccount.IsApproved,
SupplierAccount.ApprovedDate);
}
