using Domain.Enums;

namespace Application.Features;
public record LDAPConfigResponse(
 int ConfigurationId,
 string ServerAddress,
 string CN,
string DC,
ConfigurationEnum ConfigurationType
);