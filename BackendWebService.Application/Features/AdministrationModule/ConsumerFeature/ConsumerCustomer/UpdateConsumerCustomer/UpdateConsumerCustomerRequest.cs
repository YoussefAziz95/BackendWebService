using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateConsumerCustomerRequest(
int ConsumerId,
int CategoryId) : IConvertibleToEntity<ConsumerCustomer>, IRequest<int>
{
    public ConsumerCustomer ToEntity() => new ConsumerCustomer
    {

        ConsumerId = ConsumerId,
        CategoryId = CategoryId

    };
}
