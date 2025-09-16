using Application.Contracts.Features;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DepartmentRequest(
string Name,
string? Description,
int? ParentDepartmentId,
Department? ParentDepartment,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive) : IRequest<DepartmentResponse>
{
public IValidator<DepartmentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DepartmentRequest> validator)
{
throw new NotImplementedException();
}
}

