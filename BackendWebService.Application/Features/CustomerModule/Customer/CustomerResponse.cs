using Domain.Enums;

namespace Application.Features;
public record CustomerResponse(
int UserId,
RoleEnum Role,
StatusEnum Status,
List<AddCustomerServiceRequest> CustomerServiceRequest,
List<AddCustomerPaymentMethodRequest> CustomerPaymentMethodRequest,
bool MFAEnabled = false
    );