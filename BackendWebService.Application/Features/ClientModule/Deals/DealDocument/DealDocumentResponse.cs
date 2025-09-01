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
Deal Deal,
Criteria Criteria,
FileLog File,
FileFieldValidator FileFieldValidator):IConvertibleFromEntity<DealDocument, DealDocumentResponse>        
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
    DealDocument.Deal,
    DealDocument.Criteria,
    DealDocument.File,
    DealDocument.FileFieldValidator);
}
