namespace Application.Features;

public record AddEmployeeRequest(
string FirstName,
string LastName,
string Email,
string Password,
string PhoneNumber,
bool MFAEnabled = false);