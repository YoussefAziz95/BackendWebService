using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ConsumerResponse(
int OrganizationId,
string BankAccount,
decimal? Rating,
StatusEnum Status,
List<ConsumerCustomerResponse> ConsumerCustomers,
List<ConsumerAccountResponse> ConsumerAccounts) : IConvertibleFromEntity<Consumer, ConsumerResponse>
{
    public static ConsumerResponse FromEntity(Consumer Consumer) =>
    new ConsumerResponse(
    Consumer.OrganizationId,
    Consumer.BankAccount,
    Consumer.Rating,
    Consumer.Status,
    Consumer.ConsumerCustomers.Select(ConsumerCustomerResponse.FromEntity).ToList(),
    Consumer.ConsumerAccounts.Select(ConsumerAccountResponse.FromEntity).ToList());
}