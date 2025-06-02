using Domain.Enums;

namespace Application.DTOs;

public record AddCustomerRequest(string FirstName, string LastName, string Email, string Password, string PhoneNumber, bool MFAEnabled = false);

public record CustomerResponse(int Id, string FirstName, string LastName, string Email, string PhoneNumber, bool MFAEnabled, RoleEnum Role, StatusEnum Status, DateTime? CreatedDate);

public record UpdateCustomerRequest(int Id, string FirstName, string LastName, string Email, string PhoneNumber, bool MFAEnabled, StatusEnum Status);