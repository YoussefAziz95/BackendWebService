using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain;
[Table("UserRole")]
public class UserRole : IdentityUserRole<int>, IEntity, ITimeModification
{
    public int UserId { get; set; }
    [ForeignKey("ActorId")]
    public virtual User User { get; set; }
    public int RoleId { get; set; }

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }

    public int Id { get; set; }
    [AllowNull]
    public int? OrganizationId { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public bool IsSystem { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}