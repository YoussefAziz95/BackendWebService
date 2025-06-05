using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record GroupResponse(int Id, [property: Required] string Name, List<UserResponse> Users);


public record GroupDto(
    int Id,
    string Name,
    int? ActorId
);

public record GroupCreateUpdateDto(
    string Name,
    int? ActorId
);


public record UserGroupDto(
    int Id,
    int GroupId,
    int UserId
);

public record UserGroupCreateUpdateDto(
    int GroupId,
    int UserId
);
