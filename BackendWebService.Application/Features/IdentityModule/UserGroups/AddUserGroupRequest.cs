using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddUserGroupRequest(
int GroupId,
int UserId ):IConvertibleToEntity<UserGroup>
{
public UserGroup ToEntity() => new UserGroup
{
GroupId = GroupId,
UserId = UserId
};
}