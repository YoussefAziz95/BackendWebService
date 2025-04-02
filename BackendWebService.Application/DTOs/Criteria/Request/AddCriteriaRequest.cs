namespace Application.DTOs.Criteria.Request
{
    public class AddCriteriaRequest
    {
        public string Term { get; set; }
        public int FileTypeId { get; set; }
        public bool? IsRequired { get; set; }
        public int Weight { get; set; }
        public int OfferId { get; set; }

    }
}
