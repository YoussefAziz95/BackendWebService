using Application.Profiles;
using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record DealDocumentAllResponse(
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
FileLog File):IConvertibleFromEntity<DealDocument, DealDocumentAllResponse>        
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
DealDocument.FileFieldValidatorId,
DealDocument.Deal,
DealDocument.Criteria,
DealDocument.File
);
}
