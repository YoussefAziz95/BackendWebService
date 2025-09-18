using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record RoleRequest(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int? ParentId,
string DisplayName) : IRequest<RoleResponse>
{
public IValidator<RoleRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<RoleRequest> validator)
{
throw new NotImplementedException();
}
}

