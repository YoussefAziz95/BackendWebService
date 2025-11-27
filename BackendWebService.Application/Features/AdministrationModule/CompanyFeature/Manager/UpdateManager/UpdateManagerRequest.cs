using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateManagerRequest(
int OrganizationId,
string Name,
string Position) : IConvertibleToEntity<Manager>, IRequest<int>
{
    public Manager ToEntity() => new Manager
    {
        OrganizationId = OrganizationId,
        Name = Name,
        Position = Position
    };
}