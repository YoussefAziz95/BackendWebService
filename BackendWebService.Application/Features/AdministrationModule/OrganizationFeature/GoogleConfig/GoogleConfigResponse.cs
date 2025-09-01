using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record GoogleConfigResponse(
     int ConfigurationId,
    string ClientId,
    string ClientSecret,
    ConfigurationEnum ConfigurationType): IConvertibleFromEntity<GoogleConfig, GoogleConfigResponse>
{
public static GoogleConfigResponse FromEntity(GoogleConfig GoogleConfig) =>
new GoogleConfigResponse(
GoogleConfig.ConfigurationId,
GoogleConfig.ClientId,
GoogleConfig.ClientSecret,
GoogleConfig.ConfigurationType
);
}