using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ActorRequest(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType) : IRequest<ActorResponse>
{
    public IValidator<ActorRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ActorRequest> validator)
    {
        throw new NotImplementedException();
    }
}

