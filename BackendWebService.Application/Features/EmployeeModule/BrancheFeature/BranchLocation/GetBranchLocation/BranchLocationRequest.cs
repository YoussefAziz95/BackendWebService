using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchLocationRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
bool MFAEnabled = false) : IRequest<BranchLocationResponse>
{
    public IValidator<BranchLocationRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchLocationRequest> validator)
    {
        throw new NotImplementedException();
    }
}

