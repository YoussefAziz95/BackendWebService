using Application.Features.Common;

namespace Application.Features.Vendor.Responses
{
    public class GetPaginatedVendor
    {
        public int Id { get; set; }

        public int? CompanyVendorId { get; set; }



        public string Name { get; set; }



        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string? Email { get; set; }

        public string TaxNo { get; set; }
    }
}
