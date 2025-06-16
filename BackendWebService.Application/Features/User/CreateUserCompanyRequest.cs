using Domain.Enums;

namespace Application.Features;

public record CreateUserCompanyRequest(string FirstName, string LastName, string Username, string Email, string Password, int? CompanyId, string? Department, string? Title, bool IsDefaultPassword, int? OrganizationId, string MainRole = nameof(RoleEnum.Employee));
