using Domain.Enums;

namespace Application.Features;
public record UpdateCustomerRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
List<AddCustomerServiceRequest> CustomerServiceRequests,
List<AddCustomerPaymentMethodRequest> CustomerPaymentMethodRequest,
bool MFAEnabled = false
 );