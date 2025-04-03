

public class UserRefreshToken : BaseEntity<int> , IEntity, ITimeModification    
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public bool IsValid { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
    public int? OrganizationId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }
}