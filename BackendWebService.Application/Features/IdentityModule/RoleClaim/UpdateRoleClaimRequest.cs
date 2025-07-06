namespace Application.Features;
public record UpdateRoleClaimRequest(int Id, string? ClaimType, string? ClaimValue, int RoleId, DateTime? CreatedDate);