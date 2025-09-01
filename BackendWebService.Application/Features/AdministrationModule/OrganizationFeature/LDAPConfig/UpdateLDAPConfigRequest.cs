using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateLDAPConfigRequest(
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
ConfigurationType = ConfigurationType
};
}
