using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddSupplierAccountRequest(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddSupplierDocumentRequest> SupplierDocument):IConvertibleToEntity<SupplierAccount>
{
public SupplierAccount ToEntity() => new SupplierAccount
{
CompanyId = CompanyId,
SupplierId = SupplierId,
IsApproved = IsApproved,
ApprovedDate = ApprovedDate,
SupplierDocument = SupplierDocument.Select(x => x.ToEntity()).ToList()
};
}
