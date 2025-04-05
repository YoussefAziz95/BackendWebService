using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
public class UserToken : IdentityUserToken<int>, IEntity, ITimeModification
{
    public int Id { get; set; }
    public int? OrganizationId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    
    public DateTime GeneratedTime { get; set; } = DateTime.UtcNow;
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsSystem { get; set; }
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }

    //[Column(TypeName = "jsonb")] // PostgreSQL support
    public string Claims { get; set; } = "[]"; // JSON serialized claims
    [NotMapped]
    public List<string> ClaimsList
    {
        get => string.IsNullOrEmpty(Claims) ? new List<string>() : System.Text.Json.JsonSerializer.Deserialize<List<string>>(Claims);
        set => Claims = System.Text.Json.JsonSerializer.Serialize(value);
    }
}
