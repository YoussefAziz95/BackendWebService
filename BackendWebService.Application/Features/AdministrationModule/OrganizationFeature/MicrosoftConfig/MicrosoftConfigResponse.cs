using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record MicrosoftConfigResponse(
int ConfigurationId,
 string ClientId,
 string TenantId,
string Audience,
string Instance,
ConfigurationEnum ConfigurationType):IConvertibleFromEntity<MicrosoftConfig, MicrosoftConfigResponse>
{
public static MicrosoftConfigResponse FromEntity(MicrosoftConfig MicrosoftConfig) =>
new MicrosoftConfigResponse(
MicrosoftConfig.ConfigurationId,
MicrosoftConfig.ClientId,
MicrosoftConfig.TenantId,
MicrosoftConfig.Audience,
MicrosoftConfig.Instance,
MicrosoftConfig.ConfigurationType);
}
