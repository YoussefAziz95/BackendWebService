namespace Application.DTOs.Criteria.Request
{
    public class UpdateCriteriaRequest
    {
        /// <summary>
        /// Gets or sets the ID of the offer.
        /// </summary>
        public int Id { get; set; }
        public string Term { get; set; }
        public int FileTypeId { get; set; }
        public bool? IsRequired { get; set; }
        public int Weight { get; set; }
        public int OfferId { get; set; }

    }
}
