using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("UserClaim")]
public class UserClaim : IdentityUserClaim<int>, IEntity, ITimeModification
{
    public User User { get; set; }
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsSystem { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}
