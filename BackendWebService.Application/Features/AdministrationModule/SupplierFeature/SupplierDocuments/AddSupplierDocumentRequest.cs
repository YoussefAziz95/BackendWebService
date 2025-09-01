using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddSupplierDocumentRequest(
int SupplierAccountId,
int PreDocumentId,
int FileId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
PreDocument PreDocument,
SupplierAccount SupplierAccount):IConvertibleToEntity<SupplierDocument>
{
public SupplierDocument ToEntity() => new SupplierDocument
{
SupplierAccountId = SupplierAccountId,
PreDocumentId = PreDocumentId,
FileId = FileId,
ApprovedDate = ApprovedDate,
IsApproved = IsApproved,
Comment = Comment,
PreDocument= PreDocument,
SupplierAccount= SupplierAccount
};
}