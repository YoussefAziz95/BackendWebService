using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddDepartmentRequest(
string Name,
string? Description,
int? ParentDepartmentId,
Department? ParentDepartment,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive,
List<AddDepartmentRequest>? SubDepartments) : IConvertibleToEntity<Department>,IRequest<int>
{
    public Department ToEntity() => new Department
    {
        Name = Name,
        Description = Description,
        ParentDepartmentId = ParentDepartmentId,
        ParentDepartment = ParentDepartment,
        OrganizationId = OrganizationId,
        BranchId = BranchId,
        Code = Code,
        IsActive = IsActive,
        SubDepartments = SubDepartments.Select(x => x.ToEntity()).ToList()
    };
}
