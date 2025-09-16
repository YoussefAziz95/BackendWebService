using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DepartmentAllRequest(
string Name,
string? Description,
int? ParentDepartmentId,
int? OrganizationId,
int? BranchId,
string? Code,
bool IsActive,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<DepartmentAllResponse>>
{
    public IValidator<DepartmentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DepartmentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

