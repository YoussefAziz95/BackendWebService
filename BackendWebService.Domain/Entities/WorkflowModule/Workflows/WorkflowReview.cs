using System.ComponentModel.DataAnnotations;

namespace Domain;

public class WorkflowReview : BaseEntity
{
    [Required]
    public int OwnerId { get; set; } // ID of the owner of the review

    [Required]
    [MaxLength(50)]
    public string OwnerType { get; set; } = string.Empty; // Entity type of the owner (e.g., "User", "Admin")

    [Required]
    public int ObjectId { get; set; } // ID of the object being reviewed

    [Required]
    [MaxLength(50)]
    public string ObjectType { get; set; } = string.Empty; // Entity type of the object (e.g., "WorkflowCase")
}
