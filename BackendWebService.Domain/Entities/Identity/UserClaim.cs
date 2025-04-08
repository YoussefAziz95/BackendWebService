using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class UserClaim : IdentityUserClaim<int>, IEntity
{
    public User User { get; set; }
    public int? OrganizationId { get ; set ; }
    public bool? IsActive { get ; set ; }
    public bool? IsDeleted { get ; set ; }
    public bool? IsSystem { get ; set ; }
}
