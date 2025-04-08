using Application.Profiles;
using Domain;
namespace Application.DTOs.Roles;

public class RoleResponse : ICreateMapper<Role>
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public List<ClaimResponse>? Claims { get; set; }
}

public class RoleClaimRequest
{
    public string RoleId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}
public class ClaimResponse
{
    public int Id { get; set; }
    public string Value { get; set; }
}

public class CreateRoleRequest : ICreateMapper<Role>
{
    public string Name { get; set; }
    public List<string> Claims { get; set; }
}

public class AddRoleToUserRequest
{
    public int UserId { get; set; }
    public required string Role { get; set; }
}
public class RolesResponse : ICreateMapper<Role>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}

public class UpdateRoleRequest : ICreateMapper<Role>
{
    public int Id { get; set; }
    public string Role { get; set; }
    public List<string> Claims { get; set; }
}