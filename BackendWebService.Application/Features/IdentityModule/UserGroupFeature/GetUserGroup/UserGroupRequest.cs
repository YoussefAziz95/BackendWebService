using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserGroupRequest(
int GroupId,
int UserId) : IRequest<UserGroupResponse>
{
    public IValidator<UserGroupRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserGroupRequest> validator)
    {
        throw new NotImplementedException();
    }
}

