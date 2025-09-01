using Application.Profiles;
using Domain;

namespace Application.Features;
public record DepartmentResponse(
string Name,
string? Description,
int? ParentDepartmentId,
Department? ParentDepartment,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive,
List<DepartmentResponse>? Department) : IConvertibleFromEntity<Department, DepartmentResponse>
{
public static DepartmentResponse FromEntity(Department Department) =>
new DepartmentResponse(
Department.Name,
Department.Description,
Department.ParentDepartmentId,
Department.ParentDepartment,
Department.OrganizationId,
Department.BranchId,
Department.Code,
Department.IsActive,
Department.Department.Select(x => x.ToEntity()).ToList()
);
}