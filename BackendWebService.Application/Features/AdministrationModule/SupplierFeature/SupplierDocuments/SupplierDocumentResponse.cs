using Application.Profiles;
using Domain;

namespace Application.Features;
public record SupplierDocumentResponse(
     int SupplierAccountId,
    int PreDocumentId,
    int FileId,
    DateTime? ApprovedDate,
    bool IsApproved,
    string? Comment,
    PreDocument PreDocument,
    SupplierAccount SupplierAccount):IConvertibleFromEntity<SupplierDocument, SupplierDocumentResponse>        
{
public static SupplierDocumentResponse FromEntity(SupplierDocument SupplierDocument) =>
new SupplierDocumentResponse(
SupplierDocument.SupplierAccountId,
SupplierDocument.PreDocumentId,
SupplierDocument.FileId,
SupplierDocument.ApprovedDate,
SupplierDocument.IsApproved,
SupplierDocument.Comment,
SupplierDocument.PreDocument,
SupplierDocument.SupplierAccount);
}