using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddUserGroupRequest(
int GroupId,
int UserId) : IConvertibleToEntity<UserGroup>, IRequest<int>
{
    public UserGroup ToEntity() => new UserGroup
    {
        GroupId = GroupId,
        UserId = UserId
    };
}