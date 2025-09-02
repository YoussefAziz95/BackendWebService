using Application.Profiles;
using Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerCustomerRequest(
int ConsumerId,
int CategoryId): IConvertibleToEntity<ConsumerCustomer>
{
public ConsumerCustomer ToEntity() => new ConsumerCustomer
{
ConsumerId = ConsumerId,
CategoryId = CategoryId,   
};
}