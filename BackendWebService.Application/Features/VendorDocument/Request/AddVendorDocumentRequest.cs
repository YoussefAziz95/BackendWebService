namespace Application.Features;

public class AddVendorDocumentRequest
{

    public int UserId { get; set; }
    public int CompanyId { get; set; }

    public int FileId { get; set; }

    public int PreDocumentId { get; set; }
}
