using Microsoft.AspNetCore.Identity;

namespace Domain;
public class Role : IdentityRole<int>, IEntity, ITimeModification
{
    public Role()
    {
        CreatedDate = DateTime.Now;
    }
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; } = true;
    public bool? IsDeleted { get; set; } = false;
    public bool? IsSystem { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
    public int? ParentId { get; set; }


    public string DisplayName { get; set; }
    public ICollection<RoleClaim> Claims { get; set; }
    public ICollection<UserRole> Users { get; set; }

}