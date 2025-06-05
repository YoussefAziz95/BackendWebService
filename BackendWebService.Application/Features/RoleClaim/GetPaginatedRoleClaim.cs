namespace Application.Features;

public record GetPaginatedRoleClaim(int Id, string? ClaimType, string? ClaimValue, int RoleId);