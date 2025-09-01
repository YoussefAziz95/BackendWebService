using Application.Profiles;
using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerRequest(
int OrganizationId,
string BankAccount,
decimal? Rating,
StatusEnum Status,
List<UpdateConsumerCustomerRequest> AddConsumerCustomer,
List<UpdateConsumerAccountRequest> ConsumerAccounts): IConvertibleToEntity<Consumer>
{
public Consumer ToEntity() => new Consumer
{
OrganizationId = OrganizationId,
BankAccount =  BankAccount,
Rating = Rating,
ConsumerAccounts = ConsumerAccounts.Select(x => x.ToEntity()).ToList()
};
}