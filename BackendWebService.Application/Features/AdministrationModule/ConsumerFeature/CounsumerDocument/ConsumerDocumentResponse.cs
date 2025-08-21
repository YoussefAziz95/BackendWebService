using Application.Features;
using Domain;

namespace Application.Features;
public record ConsumerDocumentResponse(
   int ConsumerAccountId,
    int PreDocumentId,
    DateTime? ApprovedDate,
    bool IsApproved,
    string? Comment,
    PreDocument PreDocument,
    int? FileId
);