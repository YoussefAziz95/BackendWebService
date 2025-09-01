using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record ConsumerDocumentResponse(
   int ConsumerAccountId,
    int PreDocumentId,
    DateTime? ApprovedDate,
    bool IsApproved,
    string? Comment,
    PreDocument PreDocument,
    int? FileId): IConvertibleFromEntity<ConsumerDocument, ConsumerDocumentResponse>
{
public static ConsumerDocumentResponse FromEntity(ConsumerDocument ConsumerDocument) =>
new ConsumerDocumentResponse(
ConsumerDocument.ConsumerAccountId,
ConsumerDocument.PreDocumentId,
ConsumerDocument.ApprovedDate,
ConsumerDocument.IsApproved,
ConsumerDocument.Comment,
ConsumerDocument.PreDocument,
ConsumerDocument.FileId
);
}