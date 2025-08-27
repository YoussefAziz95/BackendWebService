using Domain;

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
List<UpdateDepartmentRequest>? Department);
