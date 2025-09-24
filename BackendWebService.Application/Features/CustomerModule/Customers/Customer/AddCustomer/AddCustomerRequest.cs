using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record AddCustomerRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
List<AddCustomerServiceRequest> CustomerServices,
List<AddCustomerPaymentMethodRequest> CustomerPaymentMethods,
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
