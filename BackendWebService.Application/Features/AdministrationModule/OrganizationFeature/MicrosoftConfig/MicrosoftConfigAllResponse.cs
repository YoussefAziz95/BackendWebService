using Domain.Enums;

namespace Application.Features;
public record MicrosoftConfigAllResponse(
 int ConfigurationId,
 string ClientId,
 string TenantId,
string Audience,
string Instance,
ConfigurationEnum ConfigurationType
 );
