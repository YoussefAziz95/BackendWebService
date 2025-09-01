using Application.Profiles;
using Domain.Enums;
using Google.Apis.Auth.OAuth2;

namespace Application.Features;
public record UpdateGoogleConfigRequest(
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
