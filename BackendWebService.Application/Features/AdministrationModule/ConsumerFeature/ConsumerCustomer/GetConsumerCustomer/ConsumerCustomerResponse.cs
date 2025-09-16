using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ConsumerCustomerResponse(
int ConsumerId,
int CategoryId) : IConvertibleFromEntity<ConsumerCustomer, ConsumerCustomerResponse>
{
    public static ConsumerCustomerResponse FromEntity(ConsumerCustomer ConsumerCustomer) =>
    new ConsumerCustomerResponse(
    ConsumerCustomer.ConsumerId,
    ConsumerCustomer.CategoryId);
}