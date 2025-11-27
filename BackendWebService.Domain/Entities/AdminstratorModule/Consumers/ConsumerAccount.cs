using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("ConsumerAccount")]
public class ConsumerAccount : BaseEntity, IEntity, ITimeModification
{
    public int CompanyId { get; set; }
    public int ConsumerId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    [ForeignKey(nameof(ConsumerId))]
    public Consumer Consumer { get; set; }

    public DateTime? ApprovedDate { get; set; }
    public bool IsApproved { get; set; }

    public ICollection<ConsumerDocument> ConsumerDocuments { get; set; } // Assuming shared with ConsumerAccount
}
