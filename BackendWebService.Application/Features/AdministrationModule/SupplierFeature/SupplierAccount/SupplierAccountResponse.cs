using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record SupplierAccountResponse(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddSupplierDocumentRequest> SupplierDocument):IConvertibleFromEntity<SupplierAccount, SupplierAccountResponse>        
{
public static SupplierAccountResponse FromEntity(SupplierAccount SupplierAccount) =>
new SupplierAccountResponse(
SupplierAccount.CompanyId,
SupplierAccount.SupplierId,
SupplierAccount.IsApproved,
SupplierAccount.ApprovedDate,
SupplierAccount.SupplierDocument.Select(x => x.ToEntity()).ToList());
}