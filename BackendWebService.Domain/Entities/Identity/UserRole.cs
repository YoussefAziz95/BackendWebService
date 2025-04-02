using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

[Table("UserRole")]
public class UserRole : IdentityUserRole<int>
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

}