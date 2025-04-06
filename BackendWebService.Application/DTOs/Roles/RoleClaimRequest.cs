namespace BackendWebService.Application.DTOs.Roles;

public class RoleClaimRequest
{
    public string RoleId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}
