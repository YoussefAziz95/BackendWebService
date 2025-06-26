using Domain;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SupplierAccount")]
public class SupplierAccount : BaseEntity, IEntity, ITimeModification
{
    public int CompanyId { get; set; }
    public int SupplierId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public Supplier Supplier { get; set; } // ✅ FIXED: was wrongly mapped to Consumer

    public DateTime? ApprovedDate { get; set; }
    public bool IsApproved { get; set; }

    public ICollection<SupplierDocument> SupplierDocuments { get; set; }
}
