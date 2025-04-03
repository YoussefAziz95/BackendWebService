using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("SupplierDocument")]
public class SupplierDocument : BaseEntity, IEntity, ITimeModification
{
    public int SupplierAccountId { get; set; }
    public int PreDocumentId { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public bool IsApproved { get; set; }
    public string? Comment { get; set; }
    public int? FileId { get; set; }
    public PreDocument PreDocument { get; set; }
    public SupplierAccount SupplierAccount { get; set; }
}