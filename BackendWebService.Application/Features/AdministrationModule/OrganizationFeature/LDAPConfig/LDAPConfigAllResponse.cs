using Domain.Enums;

namespace Application.Features;
public record LDAPConfigAllResponse(
 int ConfigurationId,
 string ServerAddress,
 string CN,
string DC,
ConfigurationEnum ConfigurationType
 );
