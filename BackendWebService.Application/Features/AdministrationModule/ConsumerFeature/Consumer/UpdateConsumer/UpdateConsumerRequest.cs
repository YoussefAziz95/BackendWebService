using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateConsumerRequest(
int OrganizationId,
string BankAccount,
decimal? Rating,
StatusEnum Status,
List<UpdateConsumerCustomerRequest> AddConsumerCustomer,
List<UpdateConsumerAccountRequest> ConsumerAccounts) : IConvertibleToEntity<Consumer>, IRequest<int>
{
    public Consumer ToEntity() => new Consumer
    {
        OrganizationId = OrganizationId,
        BankAccount = BankAccount,
        Rating = Rating,
        ConsumerAccounts = ConsumerAccounts.Select(x => x.ToEntity()).ToList()
    };
}