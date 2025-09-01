

using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddConsumerRequest(
int OrganizationId,
string BankAccount, 
decimal? Rating,
StatusEnum Status,
List<AddConsumerCustomerRequest> AddConsumerCustomer,
List<AddConsumerAccountRequest> ConsumerAccounts) : IConvertibleToEntity<Consumer>

{
public Consumer ToEntity() => new Consumer
{

OrganizationId = OrganizationId,
BankAccount = BankAccount,
Rating = Rating,
Status = Status,
ConsumerAccounts = ConsumerAccounts.Select(x => x.ToEntity()).ToList()
};
}