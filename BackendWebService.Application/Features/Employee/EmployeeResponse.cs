namespace Application.Features;

public record EmployeeResponse(
int Id,
string FirstName,
string LastName,
string Email,
string PhoneNumber,
string Role,
DateTime? CreatedDate);