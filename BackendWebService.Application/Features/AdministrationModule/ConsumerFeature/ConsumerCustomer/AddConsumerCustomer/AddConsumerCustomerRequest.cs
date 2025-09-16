using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AddConsumerCustomerRequest(
int ConsumerId,
int CategoryId) : IConvertibleToEntity<ConsumerCustomer>, IRequest<int>
{
    public ConsumerCustomer ToEntity() => new ConsumerCustomer
    {

        ConsumerId = ConsumerId,
        CategoryId = CategoryId

    };
}
