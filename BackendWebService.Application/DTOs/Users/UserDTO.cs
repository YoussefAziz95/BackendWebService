using Application.Profiles;
using Domain.Enums;
using Domain;

namespace Application.DTOs.Users;

public record UserDTO(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string PhoneNumber,
    string? Department,
    string? Title,
    string MainRole
) : ICreateMapper<User>;

public record CreateUserCompanyRequest(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password,
    int? CompanyId,
    string? Department,
    string? Title,
    bool IsDefaultPassword,
    int? OrganizationId,
    string MainRole = nameof(RoleEnum.Technician)
) : ICreateMapper<User>;

public record ChangePasswordRequest(string OldPassword, string NewPassword);

public record ActivateDeactivateOtpRequest(int Id, bool HasOtp) : ICreateMapper<User>;

public record CreateUserWithPasswordRequest(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string PhoneNumber,
    string? Department,
    string? Title,
    string MainRole
) : ICreateMapper<User>;

public record RoleAssignRequest(int UserId, string Role);

public record UpdateUserRequest(
    string? FirstName,
    string? LastName,
    string? Email,
    string? MainRole,
    int? CompanyId,
    string? Department,
    string? Title,
    List<string> Roles
);

public record UserResponse(
    int Id,
    string Username,
    string Email,
    string FirstName,
    string LastName,
    string? Department,
    string? Title,
    List<string> Roles,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdateDate,
    int? CompanyId,
    string MainRole
) : ICreateMapper<User>;