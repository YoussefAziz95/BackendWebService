using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AdministratorRequest(
int UserId,
string Attributes) : IRequest<AdministratorResponse>
{
    public IValidator<AdministratorRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AdministratorRequest> validator)
    {
        throw new NotImplementedException();
    }
}

