using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("UserRefreshToken")]
public class UserRefreshToken : BaseEntity<Guid>, IEntity, ITimeModification
{
    public UserRefreshToken()
    {
        CreatedAt = DateTime.Now;
    }

    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsValid { get; set; }
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsSystem { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
}