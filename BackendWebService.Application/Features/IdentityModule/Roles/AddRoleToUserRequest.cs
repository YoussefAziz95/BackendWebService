using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddRoleToUserRequest(int UserId, [property: Required] string Role);