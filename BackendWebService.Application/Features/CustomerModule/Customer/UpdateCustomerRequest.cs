using Domain.Enums;

namespace Application.Features;
public record UpdateCustomerRequest(
int Id,
string FirstName,
string LastName,
string Email,
string PhoneNumber,
bool MFAEnabled,
StatusEnum Status);