using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record DealDocumentResponse(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId,
DealResponse Deal,
CriteriaResponse Criteria,
FileLogResponse File,
FileFieldValidatorResponse FileFieldValidator) : IConvertibleFromEntity<DealDocument, DealDocumentResponse>
{
    public static DealDocumentResponse FromEntity(DealDocument DealDocument) =>
    new DealDocumentResponse(
    DealDocument.Score,
    DealDocument.Comment,
    DealDocument.RichText,
    DealDocument.StatusId,
    DealDocument.DealId,
    DealDocument.CriteriaId,
    DealDocument.FileId,
    DealDocument.FileFieldValidatorId,
    DealResponse.FromEntity(DealDocument.Deal),
    CriteriaResponse.FromEntity(DealDocument.Criteria),
    FileLogResponse.FromEntity(DealDocument.File),
    FileFieldValidatorResponse.FromEntity(DealDocument.FileFieldValidator));
}
