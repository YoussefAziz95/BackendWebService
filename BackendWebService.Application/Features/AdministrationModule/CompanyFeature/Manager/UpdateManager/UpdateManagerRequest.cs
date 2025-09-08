using Application.Profiles;
using Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateManagerRequest(
int OrganizationId,
string Name,
string Position) : IConvertibleToEntity<Manager>

{
    public Manager ToEntity() => new Manager
    {
        OrganizationId = OrganizationId,
        Name = Name,
        Position = Position
    };
}