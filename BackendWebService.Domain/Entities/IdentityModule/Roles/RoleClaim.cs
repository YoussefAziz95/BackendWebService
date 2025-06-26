using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Domain;

[Table("RoleClaim")]
public class RoleClaim : IdentityRoleClaim<int>, IEntity, ITimeModification
{
    public RoleClaim()
    {
        CreatedDate = DateTime.Now;
    }
    public virtual Claim ToClaim()
    {
        return new Claim(ClaimType!, ClaimValue!);
    }
    public virtual void InitializeFromClaim(Claim? other)
    {
        ClaimType = other?.Type;
        ClaimValue = other?.Value;
    }
    public RoleClaim(string value, string type) : this()
    {
        ClaimType = type;
        ClaimValue = value;
    }
    public Role Role { get; set; }
    public override string? ClaimType { get; set; }
    public override string? ClaimValue { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsSystem { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}