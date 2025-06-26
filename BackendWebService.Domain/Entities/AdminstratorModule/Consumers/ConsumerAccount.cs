using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("ConsumerAccount")]
public class ConsumerAccount : BaseEntity, IEntity, ITimeModification
{
    public int CompanyId { get; set; }
    public int SupplierId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public Consumer Supplier { get; set; }

    public DateTime? ApprovedDate { get; set; }
    public bool IsApproved { get; set; }

    public ICollection<SupplierDocument> SupplierDocuments { get; set; } // Assuming shared with SupplierAccount
}
