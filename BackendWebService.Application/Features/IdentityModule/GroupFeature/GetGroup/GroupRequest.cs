using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record GroupRequest(
string Name,
int? ActorId) : IRequest<GroupResponse>
{
    public IValidator<GroupRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<GroupRequest> validator)
    {
        throw new NotImplementedException();
    }
}

