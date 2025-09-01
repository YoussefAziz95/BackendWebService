using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record CustomerResponse(
int UserId,
RoleEnum Role,
StatusEnum Status,
List<CustomerServiceResponse> CustomerServices,
List<CustomerPaymentMethodResponse> CustomerPaymentMethods,
bool? MFAEnabled = false):IConvertibleFromEntity<Customer, CustomerResponse>        
{
public static CustomerResponse FromEntity(Customer Customer) =>
new CustomerResponse(
Customer.UserId,
Customer.Role,
Customer.Status,
Customer.CustomerServices.Select(CustomerServiceResponse.FromEntity).ToList(),
Customer.CustomerPaymentMethods.Select(CustomerPaymentMethodResponse.FromEntity).ToList(),
Customer.MFAEnabled);
}
