using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record ConsumerCustomerResponse(
int SupplierId,
int CategoryId): IConvertibleFromEntity<ConsumerCustomer, ConsumerCustomerResponse>
{
public static ConsumerCustomerResponse FromEntity(ConsumerCustomer ConsumerCustomer) =>
new ConsumerCustomerResponse(
ConsumerCustomer.SupplierId,
ConsumerCustomer.CategoryId);
}