
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("User")]
public class User : IdentityUser<int>, IEntity, ITimeModification
{
    // Basic Info
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Key]
    public string? NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; } = false;


    public string PhoneNumber { get; set; }
    public string? NormalizedPhoneNumber { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? PhoneNumberInternational { get; set; }
    public bool PhoneNumberConfirmed { get; set; } = false;

    // Security & System Flags
    public bool IsDefaultPassword { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }
    public bool HasOtp { get; set; } = false;

    // Audit Info
    public required string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    // Relationships

    public int? OrganizationId { get; set; }
    [ForeignKey("OrganizationId")]
    public Organization Organization { get; set; }
    public string Department { get; set; }
    public string Title { get; set; }

    [ForeignKey("ActorId")]
    public int? ActorId { get; set; }

    // Authentication & Authorization
    public List<RefreshToken>? RefreshTokens { get; set; }
    public List<Otp>? Otps { get; set; }
    public RoleEnum MainRole { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

}
