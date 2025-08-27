using Domain.Enums;

namespace Application.Features;
public record UpdateCustomerRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
List<UpdateCustomerServiceRequest> CustomerServiceRequests,
List<UpdateCustomerPaymentMethodRequest> CustomerPaymentMethodRequest,
bool MFAEnabled = false);