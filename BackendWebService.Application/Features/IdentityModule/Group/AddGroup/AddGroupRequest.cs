using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddGroupRequest(
string Name,
int? ActorId,
List<AddUserGroupRequest> UserGroups) : IConvertibleToEntity<Group>, IRequest<int>
{
    public Group ToEntity() => new Group
    {
        Name = Name,
        ActorId = ActorId,
        UserGroups = UserGroups.Select(x => x.ToEntity()).ToList()
    };
}