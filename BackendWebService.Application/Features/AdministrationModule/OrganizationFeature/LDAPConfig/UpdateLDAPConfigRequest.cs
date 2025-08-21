using Domain.Enums;

namespace Application.Features;
public record UpdateLDAPConfigRequest(
 int ConfigurationId,
 string ServerAddress,
 string CN,
string DC,
ConfigurationEnum ConfigurationType
 );
