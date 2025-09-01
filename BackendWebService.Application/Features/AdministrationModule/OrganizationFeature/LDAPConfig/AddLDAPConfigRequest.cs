using Application.Profiles;
using Domain;
using Domain.Enums;
using Google.Apis.Auth.OAuth2;

namespace Application.Features;
public record AddLDAPConfigRequest(
int ConfigurationId,
string ServerAddress,
string CN,
string DC,
ConfigurationEnum ConfigurationType):IConvertibleToEntity<LDAPConfig>
{
public LDAPConfig ToEntity() => new LDAPConfig
{
ConfigurationId = ConfigurationId,
ServerAddress = ServerAddress,
CN = CN,
DC = DC,
ConfigurationType=ConfigurationType
};
}
