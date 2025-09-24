using Application.Profiles;
using Domain;

namespace Application.Features;

public record DealDocumentAllResponse(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId) : IConvertibleFromEntity<DealDocument, DealDocumentAllResponse>
{
    public static DealDocumentAllResponse FromEntity(DealDocument DealDocument) =>
    new DealDocumentAllResponse(
    DealDocument.Score,
    DealDocument.Comment,
    DealDocument.RichText,
    DealDocument.StatusId,
    DealDocument.DealId,
    DealDocument.CriteriaId,
    DealDocument.FileId,
    DealDocument.FileFieldValidatorId);
}
