
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class User : IdentityUser<int>, IEntity, ITimeModification
{
    public string GeneratedCode { get; set; }
    public User()
    {
        this.GeneratedCode = Guid.NewGuid().ToString().Substring(0, 8);
        this.CreatedDate = DateTime.UtcNow;
    }
    // Basic Info
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string UserName
    {
        get => base.UserName;
        set => base.UserName = value?.Trim(); // optionally lowercase, but be safe
    }

    public override string Email
    {
        get => base.Email;
        set => base.Email = value?.Trim().ToLower(); // email is usually lowercase
    }

    public override string PhoneNumber
    {
        get => base.PhoneNumber;
        set => base.PhoneNumber = value; // optional: validate/format phone
    }

    // Security & System Flags
    public bool? IsActive { get; set; } = true;
    public bool? IsDeleted { get; set; } = false;
    public bool? IsSystem { get; set; }

    // Audit Info
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

    // Relationships

    public int? OrganizationId { get; set; }
    public string? Department { get; set; }
    public string? Title { get; set; }
    public RoleEnum MainRole { get; set; }

    // Collections
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<UserLogin> Logins { get; set; }
    public ICollection<UserClaim> Claims { get; set; }
    public ICollection<UserToken> Tokens { get; set; }
    public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    public string? CreatedBy { get ; set ; }
    public DateTime? UpdateDate { get ; set ; }
    public string? UpdatedBy { get ; set ; }
}
