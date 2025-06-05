namespace Application.Features.Response
{
    public class VendorDocumentResponse
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public int PreDocumentId { get; set; }

        public string PreDocumentName { get; set; }

        public string DocUrl { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
