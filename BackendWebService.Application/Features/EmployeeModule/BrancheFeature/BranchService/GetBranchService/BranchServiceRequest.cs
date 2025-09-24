using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchServiceRequest(
int BranchId,
int ServiceId,
string? Notes,
bool IsActive) : IRequest<BranchServiceResponse>
{
    public IValidator<BranchServiceRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchServiceRequest> validator)
    {
        throw new NotImplementedException();
    }
}

