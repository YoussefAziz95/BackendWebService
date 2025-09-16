using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierDocumentResponse(
     int SupplierAccountId,
    int PreDocumentId,
    int? FileId,
    DateTime? ApprovedDate,
    bool IsApproved,
    string? Comment,
    PreDocumentResponse PreDocument,
    SupplierAccountResponse SupplierAccount) : IConvertibleFromEntity<SupplierDocument, SupplierDocumentResponse>
{
    public static SupplierDocumentResponse FromEntity(SupplierDocument SupplierDocument) =>
    new SupplierDocumentResponse(
    SupplierDocument.SupplierAccountId,
    SupplierDocument.PreDocumentId,
    SupplierDocument.FileId,
    SupplierDocument.ApprovedDate,
    SupplierDocument.IsApproved,
    SupplierDocument.Comment,
    PreDocumentResponse.FromEntity(SupplierDocument.PreDocument),
    SupplierAccountResponse.FromEntity(SupplierDocument.SupplierAccount));
}