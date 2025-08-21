using Domain.Enums;

namespace Application.Features;
public record UpdateGoogleConfigRequest(
    int ConfigurationId,
    string ClientId,
    string ClientSecret,
    ConfigurationEnum ConfigurationType
 );
