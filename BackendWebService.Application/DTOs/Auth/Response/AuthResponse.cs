namespace Application.DTOs.Auth.Response;
public class AuthResponse
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Department { get; set; }
    public string? Title { get; set; }
    public string? MainRole { get; set; }
}