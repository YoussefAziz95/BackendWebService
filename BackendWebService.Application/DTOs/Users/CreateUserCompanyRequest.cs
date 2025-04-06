using Application.Profiles;
using Application.Validators.Common;
using Domain;
using Domain.Enums;

namespace Application.DTOs.Users;

public class CreateUserCompanyRequest : BaseValidationModel<CreateUserCompanyRequest>, ICreateMapper<User>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int? CompanyId { get; set; }
    public string Department { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsDefaultPassword { get; set; } = default;
    public int? OrganizationId { get; set; }
    public string MainRole { get; set; } = Enum.GetName(typeof(RoleEnum), RoleEnum.Technician);
}
