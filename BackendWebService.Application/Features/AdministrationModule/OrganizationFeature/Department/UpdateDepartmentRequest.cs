using Application.Profiles;
using Domain;
using Newtonsoft.Json.Linq;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Application.Features;
public record UpdateDepartmentRequest(
string Name,
string? Description,
int? ParentDepartmentId,
Department? ParentDepartment,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive,
List<UpdateDepartmentRequest>? Department):IConvertibleToEntity<Department>
{
public Department ToEntity() => new Department
{
Name = Name,
Description = Description,
ParentDepartmentId = ParentDepartmentId,
OrganizationId = OrganizationId,
BranchId= BranchId,
Code= Code,
IsActive= IsActive,
Department= Department.Select(x => x.ToEntity()).ToList()
};
}
