using Application.Profiles;
using Domain;

namespace Application.Features;

public record DepartmentAllResponse(
string Name,
string? Description,
int? ParentDepartmentId,
Department? ParentDepartment,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive) : IConvertibleFromEntity<Department, DepartmentAllResponse>
{
    public static DepartmentAllResponse FromEntity(Department Department) =>
    new DepartmentAllResponse(
    Department.Name,
    Department.Description,
    Department.ParentDepartmentId,
    Department.ParentDepartment,
    Department.OrganizationId,
    Department.BranchId,
    Department.Code,
    Department.IsActive
    );
}

