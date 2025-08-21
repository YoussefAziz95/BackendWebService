using Domain.Enums;

namespace Application.Features;
public record GoogleConfigResponse(
     int ConfigurationId,
    string ClientId,
    string ClientSecret,
    ConfigurationEnum ConfigurationType
    );