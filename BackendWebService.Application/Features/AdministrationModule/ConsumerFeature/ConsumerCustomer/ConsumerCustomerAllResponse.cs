using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record ConsumerCustomerAllResponse(
    int SupplierId,
    int CategoryId): IConvertibleFromEntity<ConsumerCustomer, ConsumerCustomerAllResponse>
{
public static ConsumerCustomerAllResponse FromEntity(ConsumerCustomer ConsumerCustomer) =>
new ConsumerCustomerAllResponse(
ConsumerCustomer.SupplierId,
ConsumerCustomer.CategoryId);
}