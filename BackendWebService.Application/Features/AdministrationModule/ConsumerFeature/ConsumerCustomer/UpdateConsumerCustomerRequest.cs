using Application.Profiles;
using Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerCustomerRequest(
int SupplierId,
int CategoryId): IConvertibleToEntity<ConsumerCustomer>
{
public ConsumerCustomer ToEntity() => new ConsumerCustomer
{
SupplierId = SupplierId,
CategoryId = CategoryId,   
};
}