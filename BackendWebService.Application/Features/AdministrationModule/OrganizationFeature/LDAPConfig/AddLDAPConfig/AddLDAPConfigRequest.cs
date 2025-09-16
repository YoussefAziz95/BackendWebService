using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddLDAPConfigRequest(
int ConfigurationId,
string ServerAddress,
string CN,
string DC,
ConfigurationEnum ConfigurationType) : IConvertibleToEntity<LDAPConfig>,IRequest<int>
{
    public LDAPConfig ToEntity() => new LDAPConfig
    {
        ConfigurationId = ConfigurationId,
        ServerAddress = ServerAddress,
        CN = CN,
        DC = DC,
        ConfigurationType = ConfigurationType
    };
}
