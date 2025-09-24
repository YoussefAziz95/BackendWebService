using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record LDAPConfigRequest(
int ConfigurationId,
string ServerAddress,
string CN,
string DC,
ConfigurationEnum ConfigurationType) : IRequest<LDAPConfigResponse>
{
    public IValidator<LDAPConfigRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<LDAPConfigRequest> validator)
    {
        throw new NotImplementedException();
    }
}

