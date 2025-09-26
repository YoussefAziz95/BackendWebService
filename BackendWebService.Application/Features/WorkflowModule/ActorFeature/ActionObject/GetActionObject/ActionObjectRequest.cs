using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ActionObjectRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType) : IRequest<ActionObjectResponse>
{
    public IValidator<ActionObjectRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ActionObjectRequest> validator)
    {
        throw new NotImplementedException();
    }
}

