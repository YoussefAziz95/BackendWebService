using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateConsumerDocumentRequest(
int ConsumerAccountId,
int PreDocumentId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
PreDocument PreDocument,
int? FileId) : IConvertibleToEntity<ConsumerDocument>, IRequest<int>
{
    public ConsumerDocument ToEntity() => new ConsumerDocument
    {

        ConsumerAccountId = ConsumerAccountId,
        PreDocumentId = PreDocumentId,
        ApprovedDate = ApprovedDate,
        IsApproved = IsApproved,
        Comment = Comment,
        PreDocument = PreDocument,
        FileId = FileId
    };
}
