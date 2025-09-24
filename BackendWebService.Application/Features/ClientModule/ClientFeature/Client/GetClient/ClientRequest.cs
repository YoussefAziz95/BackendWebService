using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientRequest(
 int UserId,
 bool MFAEnabled,
 RoleEnum Role,
 StatusEnum Status) : IRequest<ClientResponse>
{
    public IValidator<ClientRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientRequest> validator)
    {
        throw new NotImplementedException();
    }
}

