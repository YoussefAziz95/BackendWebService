namespace Application.Features;
public record RoleClaimResponse(int Id, string? ClaimType, string? ClaimValue, int RoleId, DateTime? CreatedDate);