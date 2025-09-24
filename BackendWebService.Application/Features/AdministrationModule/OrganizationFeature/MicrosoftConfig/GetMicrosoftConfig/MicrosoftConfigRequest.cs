using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record MicrosoftConfigRequest(
int ConfigurationId,
string ClientId,
string TenantId,
string Audience,
string Instance,
ConfigurationEnum ConfigurationType) : IRequest<MicrosoftConfigResponse>
{
    public IValidator<MicrosoftConfigRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<MicrosoftConfigRequest> validator)
    {
        throw new NotImplementedException();
    }
}

