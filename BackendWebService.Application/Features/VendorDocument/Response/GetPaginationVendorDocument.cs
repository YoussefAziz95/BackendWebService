namespace Application.Features
{
    public class VendorDocumentsResponse
    {
        public int? Id { get; set; }

        public string PreDocumentName { get; set; }

        public bool? IsApproved { get; set; }

        public int? FileId { get; set; }

        public int PreDocumentId { get; set; }
    }
}
