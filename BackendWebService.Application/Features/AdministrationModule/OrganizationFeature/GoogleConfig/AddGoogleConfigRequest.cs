using Domain.Enums;

namespace Application.Features;
public record AddGoogleConfigRequest(
    int ConfigurationId,
    string ClientId,
    string ClientSecret,
    ConfigurationEnum ConfigurationType
);
