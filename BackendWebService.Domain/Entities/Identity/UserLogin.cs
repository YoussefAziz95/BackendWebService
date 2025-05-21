using Microsoft.AspNetCore.Identity;

namespace Domain;

public class UserLogin : IdentityUserLogin<int>, IEntity
{
    public UserLogin()
    {
        LoggedOn = DateTime.Now;
    }

    public User User { get; set; }
    public DateTime LoggedOn { get; set; }
    public int Id { get; set; }
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsSystem { get; set; }
}

