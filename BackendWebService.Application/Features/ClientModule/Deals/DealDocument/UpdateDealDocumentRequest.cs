using Application.Profiles;
using Domain;

namespace Application.Features;

public record UpdateDealDocumentRequest(
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
FileFieldValidator FileFieldValidator):IConvertibleToEntity<DealDocument>
{
public DealDocument ToEntity() => new DealDocument
{
Score = Score,
Comment = Comment,
RichText = RichText,
StatusId = StatusId,
DealId = DealId,
CriteriaId = CriteriaId,
FileId = FileId,
FileFieldValidatorId = FileFieldValidatorId,
Deal = Deal,
Criteria = Criteria,
File = File,
};
}
