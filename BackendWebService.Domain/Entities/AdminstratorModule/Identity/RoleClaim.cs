using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Domain;

public class RoleClaim : IdentityRoleClaim<int>
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
}