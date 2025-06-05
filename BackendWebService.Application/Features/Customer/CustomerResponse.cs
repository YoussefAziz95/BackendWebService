using Domain.Enums;

namespace Application.Features;

public record CustomerResponse(int Id, string FirstName, string LastName, string Email, string PhoneNumber, bool MFAEnabled, RoleEnum Role, StatusEnum Status, DateTime? CreatedDate);