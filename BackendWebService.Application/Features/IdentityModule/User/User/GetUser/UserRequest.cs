using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserRequest(
string FirstName,
string LastName,
string UserName,
string Email,
string PhoneNumber,
string? Department,
string? Title,
RoleEnum MainRole,
int? OrganizationId,
string? CreatedBy,
DateTime? CreatedDate,
DateTime? UpdatedDate,
string? UpdatedBy,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem) : IRequest<UserResponse>
{
    public IValidator<UserRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserRequest> validator)
    {
        throw new NotImplementedException();
    }
}

