using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class UserLogin : IdentityUserLogin<int>, IEntity, ITimeModification
{
    public int Id { get; set; }
    public int? OrganizationId { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSystem { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime LoggedOn { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}

