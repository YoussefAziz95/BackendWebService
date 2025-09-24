using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record GoogleConfigRequest(
int ConfigurationId,
string ClientId,
string ClientSecret,
ConfigurationEnum ConfigurationType) : IRequest<GoogleConfigResponse>
{
    public IValidator<GoogleConfigRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<GoogleConfigRequest> validator)
    {
        throw new NotImplementedException();
    }
}

