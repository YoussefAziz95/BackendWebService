using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record ConsumerAllResponse(
int OrganizationId,
string BankAccount,
decimal? Rating,
StatusEnum Status) : IConvertibleFromEntity<Consumer, ConsumerAllResponse>

{
    public static ConsumerAllResponse FromEntity(Consumer Consumer) =>
    new ConsumerAllResponse(
    Consumer.OrganizationId,
    Consumer.BankAccount,
    Consumer.Rating,
    Consumer.Status);
}