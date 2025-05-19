using Domain.Enums;
using Domain;

namespace Application.DTOs;

public record AddUserRequest(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string PhoneNumber,
    string? Department,
    string? Title,
    string MainRole
);


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
);


public record ChangePasswordRequest(string OldPassword, string NewPassword);

public record ActivateDeactivateOtpRequest(int Id, bool HasOtp);



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
);
public record UserPagesResponse(
    int Id,
    string? Groups,
    string? Menu,
    string? Page,
    string? Permission,
    string? value
);