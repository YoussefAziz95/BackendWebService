namespace Application.Features;

public record RoleClaimRequest(string RoleId, string ClaimType, string ClaimValue);