using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain;
[Table("Role")]
public class Role : IdentityRole<int>, IEntity, ITimeModification
{
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
    public int? ParentId { get; set; }
    public required ICollection<RoleClaim> RoleClaim { get; set; }

}