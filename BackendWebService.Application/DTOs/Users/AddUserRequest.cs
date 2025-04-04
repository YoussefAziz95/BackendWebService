using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;

namespace Application.DTOs.Users;
public class AddUserRequest : BaseValidationModel<AddUserRequest>, ICreateMapper<User>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Department { get; set; }
    public string? Title { get; set; }
    public required string MainRole { get; set; }
}
