using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("UserClaim")]
public class UserClaim : IdentityUserClaim<int>, IEntity, ITimeModification
{

    public override string? ClaimType { get; set; }
    public override string? ClaimValue { get; set; }
    public override int UserId { get; set; }
    public User User { get; set; }
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsSystem { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
}
