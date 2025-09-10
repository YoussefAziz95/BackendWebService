using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
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
List<UpdateDepartmentRequest>? SubDepartments) : IConvertibleToEntity<Department>, IRequest<int>
{
    public Department ToEntity() => new Department
    {
        Name = Name,
        Description = Description,
        ParentDepartmentId = ParentDepartmentId,
        OrganizationId = OrganizationId,
        BranchId = BranchId,
        Code = Code,
        IsActive = IsActive,
        SubDepartments = SubDepartments.Select(x => x.ToEntity()).ToList()
    };
}


