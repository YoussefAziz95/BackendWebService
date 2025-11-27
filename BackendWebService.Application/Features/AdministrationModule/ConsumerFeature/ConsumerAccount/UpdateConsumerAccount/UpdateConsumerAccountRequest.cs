using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateConsumerAccountRequest(
int CompanyId,
int ConsumerId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddConsumerDocumentRequest> ConsumerDocuments) : IConvertibleToEntity<ConsumerAccount>, IRequest<int>
{
    public ConsumerAccount ToEntity() => new ConsumerAccount
    {

        ConsumerId = ConsumerId,
        CompanyId = CompanyId,
        IsApproved = IsApproved,
        ApprovedDate = ApprovedDate,
        ConsumerDocuments = ConsumerDocuments.Select(x => x.ToEntity()).ToList()
    };
}