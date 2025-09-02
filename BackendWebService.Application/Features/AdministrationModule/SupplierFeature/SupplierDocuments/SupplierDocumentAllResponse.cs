using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierDocumentAllResponse(
int SupplierAccountId,
int PreDocumentId,
int? FileId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
PreDocument PreDocument,
SupplierAccount SupplierAccount):IConvertibleFromEntity<SupplierDocument, SupplierDocumentAllResponse>        
{
public static SupplierDocumentAllResponse FromEntity(SupplierDocument SupplierDocument) =>
new SupplierDocumentAllResponse(
SupplierDocument.SupplierAccountId,
SupplierDocument.PreDocumentId,
SupplierDocument.FileId,
SupplierDocument.ApprovedDate,
SupplierDocument.IsApproved,
SupplierDocument.Comment,
SupplierDocument.PreDocument,
SupplierDocument.SupplierAccount);
}
