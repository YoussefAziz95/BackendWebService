using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain;
using System.Security.Claims;

namespace Domain;

public class RoleClaim : IdentityRoleClaim<int>, IEntity, ITimeModification
{
    /// <summary>
    /// Gets or sets the identifier for this role claim.
    /// </summary>
    public virtual int Id { get; set; } = default!;

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
   
    public override int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public override string? ClaimType { get; set; }
    public override string? ClaimValue { get; set; }
    public int? OrganizationId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }
    public DateTime CreatedDate { get; set; }
     public string? CreatedBy { get ; set ; }
    public DateTime? UpdateDate { get ; set ; }
    public string? UpdatedBy { get ; set ; }
}