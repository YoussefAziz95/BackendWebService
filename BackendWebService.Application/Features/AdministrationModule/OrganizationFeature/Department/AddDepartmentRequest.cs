using Application.Profiles;
using Domain;

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
List<AddDepartmentRequest>? SubDepartments) :IConvertibleToEntity<Department>
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
