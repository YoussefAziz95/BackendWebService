namespace Application.Features;
public class AddPermissionsToRoleRequest
{
    public int RoleId { get; set; }

    public IList<string> Claims { get; set; }
}
