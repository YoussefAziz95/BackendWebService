using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;
namespace Application.Features;
public record UpdateGoogleConfigRequest(
int ConfigurationId,
string ClientId,
string ClientSecret,
ConfigurationEnum ConfigurationType) : IConvertibleToEntity<GoogleConfig>, IRequest<int>
{
    public GoogleConfig ToEntity() => new GoogleConfig
    {
        ConfigurationId = ConfigurationId,
        ClientId = ClientId,
        ClientSecret = ClientSecret,
        ConfigurationType = ConfigurationType
    };
}


