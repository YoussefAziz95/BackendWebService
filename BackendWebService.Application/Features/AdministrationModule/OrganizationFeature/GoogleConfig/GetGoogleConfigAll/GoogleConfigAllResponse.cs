using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record GoogleConfigAllResponse(
int ConfigurationId,
string ClientId,
string ClientSecret,
ConfigurationEnum ConfigurationType) : IConvertibleFromEntity<GoogleConfig, GoogleConfigAllResponse>
{
    public static GoogleConfigAllResponse FromEntity(GoogleConfig GoogleConfig) =>
    new GoogleConfigAllResponse(
    GoogleConfig.ConfigurationId,
    GoogleConfig.ClientId,
    GoogleConfig.ClientSecret,
    GoogleConfig.ConfigurationType
    );
}
