using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("SupplierAccount")]
public class ConsumerAccount : BaseEntity, IEntity, ITimeModification
{
    public int CompanyId { get; set; }
    public int SupplierId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }
    [ForeignKey("SupplierId")]
    public Consumer Supplier { get; set; }

    public DateTime? ApprovedDate { get; set; }
    public bool IsApproved { get; set; }
    public ICollection<SupplierDocument> SupplierDocuments { get; set; }
}