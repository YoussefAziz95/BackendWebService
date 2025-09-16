using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record MicrosoftConfigAllResponse(
int ConfigurationId,
string ClientId,
string TenantId,
string Audience,
string Instance,
ConfigurationEnum ConfigurationType) : IConvertibleFromEntity<MicrosoftConfig, MicrosoftConfigAllResponse>
{
    public static MicrosoftConfigAllResponse FromEntity(MicrosoftConfig MicrosoftConfig) =>
    new MicrosoftConfigAllResponse(
    MicrosoftConfig.ConfigurationId,
    MicrosoftConfig.ClientId,
    MicrosoftConfig.TenantId,
    MicrosoftConfig.Audience,
    MicrosoftConfig.Instance,
    MicrosoftConfig.ConfigurationType);
}
