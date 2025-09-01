using Application.Profiles;
using Domain;
using Domain.Enums;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Application.Features;
public record AddGoogleConfigRequest(
int ConfigurationId,
string ClientId,
string ClientSecret,
ConfigurationEnum ConfigurationType):IConvertibleToEntity<GoogleConfig>
{
public GoogleConfig ToEntity() => new GoogleConfig
{
ConfigurationId = ConfigurationId,
ClientId = ClientId,
ClientSecret = ClientSecret,
ConfigurationType = ConfigurationType
};
}
