using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record LDAPConfigResponse(
int ConfigurationId,
string ServerAddress,
string CN,
string DC,
ConfigurationEnum ConfigurationType) : IConvertibleFromEntity<LDAPConfig, LDAPConfigResponse>
{
    public static LDAPConfigResponse FromEntity(LDAPConfig LDAPConfig) =>
    new LDAPConfigResponse(
    LDAPConfig.ConfigurationId,
    LDAPConfig.ServerAddress,
    LDAPConfig.CN,
    LDAPConfig.DC,
    LDAPConfig.ConfigurationType);
}