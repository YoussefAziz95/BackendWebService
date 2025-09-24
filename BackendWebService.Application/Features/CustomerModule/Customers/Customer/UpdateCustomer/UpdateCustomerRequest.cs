using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;
namespace Application.Features;
public record UpdateCustomerRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
List<UpdateCustomerServiceRequest> CustomerServices,
List<UpdateCustomerPaymentMethodRequest> CustomerPaymentMethods,
bool MFAEnabled = false) : IConvertibleToEntity<Customer>, IRequest<int>
{
    public Customer ToEntity() => new Customer
    {
        UserId = UserId,
        Role = Role,
        Status = Status,
        MFAEnabled = MFAEnabled,
        CustomerServices = CustomerServices.Select(x => x.ToEntity()).ToList(),
        CustomerPaymentMethods = CustomerPaymentMethods.Select(x => x.ToEntity()).ToList()
    };
}
