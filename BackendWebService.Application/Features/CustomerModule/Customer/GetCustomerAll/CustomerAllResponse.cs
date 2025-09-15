using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record CustomerAllResponse(
int UserId,
RoleEnum Role,
StatusEnum Status,
bool MFAEnabled = false) : IConvertibleFromEntity<Customer, CustomerAllResponse>
{
    public static CustomerAllResponse FromEntity(Customer Customer) =>
    new CustomerAllResponse(
    Customer.UserId,
    Customer.Role,
    Customer.Status,
    Customer.MFAEnabled);
}
