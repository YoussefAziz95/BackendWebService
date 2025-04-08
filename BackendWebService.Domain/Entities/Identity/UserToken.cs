using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
public class UserToken : IdentityUserToken<int>, IEntity
{
    public UserToken()
    {
        GeneratedTime = DateTime.Now;
    }

    public User User { get; set; }
    public DateTime GeneratedTime { get; set; }
    public int Id { get ; set ; }
    public int? OrganizationId { get ; set ; }
    public bool? IsActive { get ; set ; }
    public bool? IsDeleted { get ; set ; }
    public bool? IsSystem { get ; set ; }
}
