using Domain.Enums;

namespace Application.Features;

public record AddUserRequest(string FirstName, string LastName, string UserName, string Email, string PhoneNumber, string? Department, string? Title, string MainRole);
