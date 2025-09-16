using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record ConsumerAccountAllResponse(
int CompanyId,
int ConsumerId,
bool IsApproved,
DateTime? ApprovedDate) : IConvertibleFromEntity<ConsumerAccount, ConsumerAccountAllResponse>
{
    public static ConsumerAccountAllResponse FromEntity(ConsumerAccount ConsumerAccount) =>
    new ConsumerAccountAllResponse(
    ConsumerAccount.CompanyId,
    ConsumerAccount.ConsumerId,
    ConsumerAccount.IsApproved,
    ConsumerAccount.ApprovedDate);
}