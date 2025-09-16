using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchEmployeeRequest(
int BranchId,
int UserId,
string? JobTitle,
bool IsActive,
DateTime AssignedAt) : IRequest<BranchEmployeeResponse>, IRequest<int>
{
    public IValidator<BranchEmployeeRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchEmployeeRequest> validator)
    {
        throw new NotImplementedException();
    }
}

