
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Role")]
public class Role : IdentityRole<int>
{
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }
    public int? ParentId { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

}