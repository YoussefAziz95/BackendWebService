namespace Application.Features;

public record EmployeeAllResponse(
int Id,
string FirstName,
string LastName,
string Email,
string PhoneNumber,
string Role,
DateTime? CreatedDate);