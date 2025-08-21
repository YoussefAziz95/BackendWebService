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
    SupplierAccount SupplierAccount
    );