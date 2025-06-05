using Domain.Enums;

namespace Application.Features;

public record UpdateUserRequest(string? FirstName, string? LastName, string? Email, string? MainRole, int? CompanyId, string? Department, string? Title, List<string> Roles);
