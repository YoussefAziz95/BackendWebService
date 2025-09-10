using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierAccountResponse(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<SupplierDocumentResponse> SupplierDocuments) : IConvertibleFromEntity<SupplierAccount, SupplierAccountResponse>
{
    public static SupplierAccountResponse FromEntity(SupplierAccount SupplierAccount) =>
    new SupplierAccountResponse(
    SupplierAccount.CompanyId,
    SupplierAccount.SupplierId,
    SupplierAccount.IsApproved,
    SupplierAccount.ApprovedDate,
    SupplierAccount.SupplierDocuments.Select(SupplierDocumentResponse.FromEntity).ToList());
}