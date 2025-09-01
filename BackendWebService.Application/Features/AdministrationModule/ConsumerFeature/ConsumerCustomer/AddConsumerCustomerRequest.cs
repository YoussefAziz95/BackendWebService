using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddConsumerCustomerRequest(
int ConsumerId,
int CategoryId):IConvertibleToEntity<ConsumerCustomer>
{
public ConsumerCustomer ToEntity() => new ConsumerCustomer
{

ConsumerId = ConsumerId,
CategoryId = CategoryId
   
};
}
