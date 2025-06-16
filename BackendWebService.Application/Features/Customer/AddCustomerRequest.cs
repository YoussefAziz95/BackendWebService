namespace Application.Features;

public record AddCustomerRequest(
string FirstName,
string LastName,
string Email,
string Password,
string PhoneNumber,
bool MFAEnabled = false);
