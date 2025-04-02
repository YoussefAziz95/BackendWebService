using System.ComponentModel.DataAnnotations.Schema;

[Table("SupplierDocument")]
public class SupplierDocument : BaseEntity
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