namespace Application.Features;
public record UserResponse(int Id, string Username, string Email, string FirstName, string LastName, string? Department, string? Title, List<string> Roles, bool IsActive, DateTime CreatedDate, DateTime? UpdateDate, int? CompanyId, string MainRole);
