namespace Application.Features;
public record AddRoleClaimRequest(string? ClaimType, string? ClaimValue, int RoleId, DateTime? CreatedDate = default);