namespace BackendWebService.Application.Features.Criteria
{
    public class CriteriaResponse
    {
        public int Id { get; set; }
        public string Term { get; set; }

        public bool? IsRequired { get; set; }

        public int OfferId { get; set; }

        public int Weight { get; set; }

        public int FileTypeId { get; set; }
    }
}
