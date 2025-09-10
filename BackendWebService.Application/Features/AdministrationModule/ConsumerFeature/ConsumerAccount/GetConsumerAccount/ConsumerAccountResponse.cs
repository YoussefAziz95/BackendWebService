using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ConsumerAccountResponse(
int CompanyId,
int ConsumerId,
bool IsApproved,
DateTime? ApprovedDate,
List<ConsumerDocumentResponse> ConsumerDocument) : IConvertibleFromEntity<ConsumerAccount, ConsumerAccountResponse>
{
    public static ConsumerAccountResponse FromEntity(ConsumerAccount ConsumerAccount) =>
    new ConsumerAccountResponse(
    ConsumerAccount.CompanyId,
    ConsumerAccount.ConsumerId,
    ConsumerAccount.IsApproved,
    ConsumerAccount.ApprovedDate,
    ConsumerAccount.ConsumerDocuments.Select(ConsumerDocumentResponse.FromEntity).ToList());
}