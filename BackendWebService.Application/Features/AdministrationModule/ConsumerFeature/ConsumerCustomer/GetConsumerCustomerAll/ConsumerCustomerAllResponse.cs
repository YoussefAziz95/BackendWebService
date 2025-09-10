using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record ConsumerCustomerAllResponse(
    int ConsumerId,
    int CategoryId) : IConvertibleFromEntity<ConsumerCustomer, ConsumerCustomerAllResponse>
{
    public static ConsumerCustomerAllResponse FromEntity(ConsumerCustomer ConsumerCustomer) =>
    new ConsumerCustomerAllResponse(
    ConsumerCustomer.ConsumerId,
    ConsumerCustomer.CategoryId);
}