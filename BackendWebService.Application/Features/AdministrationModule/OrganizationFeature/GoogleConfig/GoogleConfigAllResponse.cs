using Domain.Enums;

namespace Application.Features;
public record GoogleConfigAllResponse(
    int ConfigurationId,
    string ClientId,
    string ClientSecret,
    ConfigurationEnum ConfigurationType
    );
