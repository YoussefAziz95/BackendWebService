using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserRoleRequest(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IRequest<UserRoleResponse>
{
    public IValidator<UserRoleRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserRoleRequest> validator)
    {
        throw new NotImplementedException();
    }
}

