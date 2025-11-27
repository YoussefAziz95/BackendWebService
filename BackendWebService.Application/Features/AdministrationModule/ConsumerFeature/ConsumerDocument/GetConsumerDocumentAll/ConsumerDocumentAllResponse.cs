using Application.Profiles;
using Domain;

namespace Application.Features;

public record ConsumerDocumentAllResponse(
int ConsumerAccountId,
int PreDocumentId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
PreDocument PreDocument,
int? FileId) : IConvertibleFromEntity<ConsumerDocument, ConsumerDocumentAllResponse>
{
    public static ConsumerDocumentAllResponse FromEntity(ConsumerDocument ConsumerDocument) =>
    new ConsumerDocumentAllResponse(
    ConsumerDocument.ConsumerAccountId,
    ConsumerDocument.PreDocumentId,
    ConsumerDocument.ApprovedDate,
    ConsumerDocument.IsApproved,
    ConsumerDocument.Comment,
    ConsumerDocument.PreDocument,
    ConsumerDocument.FileId
    );
}