namespace Application.Features
{
    public class UpdateRangeVendorCategoryRequest
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
