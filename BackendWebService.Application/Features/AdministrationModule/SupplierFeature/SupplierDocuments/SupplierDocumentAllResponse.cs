using Domain;
using Domain.Enums;

namespace Application.Features;
public record SupplierDocumentAllResponse(
   int SupplierAccountId,
    int PreDocumentId,
    int FileId,
    DateTime? ApprovedDate,
    bool IsApproved,
    string? Comment,
    PreDocument PreDocument,
    SupplierAccount SupplierAccount
 );
