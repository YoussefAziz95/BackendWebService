using Domain.Enums;

namespace Application.Features;
public record AddLDAPConfigRequest(
 int ConfigurationId,
 string ServerAddress,
 string CN,
string DC,
ConfigurationEnum ConfigurationType
);
