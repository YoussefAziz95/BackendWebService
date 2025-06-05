namespace Application.Features;

public record CreateUserWithPasswordRequest(string FirstName, string LastName, string Email, string Password, string PhoneNumber, string MainRole, string? Department, string? Title);
