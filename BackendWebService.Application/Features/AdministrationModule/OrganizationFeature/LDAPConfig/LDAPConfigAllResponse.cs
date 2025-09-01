using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record LDAPConfigAllResponse(
int ConfigurationId,
string ServerAddress,
string CN,
string DC,
ConfigurationEnum ConfigurationType): IConvertibleFromEntity<LDAPConfig, LDAPConfigAllResponse>
{
public static LDAPConfigAllResponse FromEntity(LDAPConfig LDAPConfig) =>
new LDAPConfigAllResponse(
LDAPConfig.ConfigurationId,
LDAPConfig.ServerAddress,
LDAPConfig.CN,
LDAPConfig.DC,
LDAPConfig.ConfigurationType);
}
