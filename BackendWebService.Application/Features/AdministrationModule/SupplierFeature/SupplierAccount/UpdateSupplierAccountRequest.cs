using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateSupplierAccountRequest(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<UpdateSupplierDocumentRequest> SupplierDocuments):IConvertibleToEntity<SupplierAccount>
{
public SupplierAccount ToEntity() => new SupplierAccount
{
CompanyId = CompanyId,
SupplierId = SupplierId,
IsApproved = IsApproved,
ApprovedDate = ApprovedDate,
SupplierDocuments = SupplierDocuments.Select(x => x.ToEntity()).ToList()
};
}
