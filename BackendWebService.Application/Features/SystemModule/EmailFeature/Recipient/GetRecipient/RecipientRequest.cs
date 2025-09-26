using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record RecipientRequest(
int ReceiverId,
int EmailId) : IRequest<RecipientResponse>
{
    public IValidator<RecipientRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<RecipientRequest> validator)
    {
        throw new NotImplementedException();
    }
}

