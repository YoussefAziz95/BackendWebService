using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddManagerRequest(
int OrganizationId,
string Name,
string Position,
List<AddManagerRequest> Manager) : IConvertibleToEntity<Manager>
{
public Manager ToEntity() => new Manager
{
OrganizationId = OrganizationId,
Name = Name,
Position = Position
};
}
