using Domain;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ConsumerDocument")]
public class ConsumerDocument : BaseEntity, IEntity, ITimeModification
{
    public int ConsumerAccountId { get; set; }
    public int PreDocumentId { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public bool IsApproved { get; set; }
    public string? Comment { get; set; }
    public int? FileId { get; set; }
    [ForeignKey(nameof(PreDocumentId))]
    public PreDocument PreDocument { get; set; }
    [ForeignKey(nameof(ConsumerAccountId))]
    public ConsumerAccount ConsumerAccount { get; set; } 
}
