using Application.Profiles;
using Domain;

namespace Application.Features;
public record DepartmentResponse(
string Name,
string? Description,
int? ParentDepartmentId,
DepartmentResponse? ParentDepartment,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive,
List<DepartmentResponse>? SubDepartments) : IConvertibleFromEntity<Department, DepartmentResponse>
{
public static DepartmentResponse FromEntity(Department Department) => new DepartmentResponse(
Department.Name,
Department.Description,
Department.ParentDepartmentId,
FromEntity(Department.ParentDepartment),
Department.OrganizationId,
Department.BranchId,
Department.Code,
Department.IsActive,
Department.SubDepartments.Select(FromEntity).ToList()
);
}