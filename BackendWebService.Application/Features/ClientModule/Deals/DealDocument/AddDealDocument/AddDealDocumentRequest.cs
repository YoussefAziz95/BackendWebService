using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddDealDocumentRequest(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId,
AddDealRequest Deal,
AddCriteriaRequest Criteria,
AddFileLogRequest File,
AddFileFieldValidatorRequest FileFieldValidator) : IConvertibleToEntity<DealDocument>,IRequest<int>
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
        Deal = Deal.ToEntity(),
        Criteria = Criteria.ToEntity(),
        File = File.ToEntity(),
    };
}