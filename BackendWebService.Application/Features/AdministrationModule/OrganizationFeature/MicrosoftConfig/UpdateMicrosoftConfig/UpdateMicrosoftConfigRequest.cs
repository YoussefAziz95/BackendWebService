using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateMicrosoftConfigRequest(
int ConfigurationId,
string ClientId,
string TenantId,
string Audience,
string Instance,
ConfigurationEnum ConfigurationType) : IConvertibleToEntity<MicrosoftConfig>,IRequest<int>
{
    public MicrosoftConfig ToEntity() => new MicrosoftConfig
    {
        ConfigurationId = ConfigurationId,
        ClientId = ClientId,
        TenantId = TenantId,
        Audience = Audience,
        Instance = Instance,
        ConfigurationType = ConfigurationType
    };
}

