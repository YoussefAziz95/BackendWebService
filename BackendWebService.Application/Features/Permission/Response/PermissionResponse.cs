namespace Application.Features;

public class PermissionResponse
{
    public int RoleId { get; set; }

    public required string Name { get; set; }

    public List<ClaimResponse>? Claims { get; set; }
}
