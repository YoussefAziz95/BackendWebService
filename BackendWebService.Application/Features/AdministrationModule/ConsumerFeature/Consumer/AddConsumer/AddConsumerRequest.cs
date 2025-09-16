using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AddConsumerRequest(
int OrganizationId,
string BankAccount,
decimal? Rating,
StatusEnum Status,
List<AddConsumerCustomerRequest> AddConsumerCustomer,
List<AddConsumerAccountRequest> ConsumerAccounts) : IConvertibleToEntity<Consumer>, IRequest<int>

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
