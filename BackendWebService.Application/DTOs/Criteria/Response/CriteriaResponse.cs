using Application.DTOs.FileType.Response;

namespace Application.DTOs.Criteria.Response
{
    /// <summary>
    /// Represents a response DTO for the Criteria entity.
    /// </summary>
    public class CriteriaResponse
    {
        /// <summary>
        /// Gets or sets the ID of the offer.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the term or condition specified by this criteria.
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this criteria is required.
        /// If true, the criteria must be met for the offer to be valid.
        /// </summary>
        public bool? IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the ID of the offer associated with this criteria.
        /// </summary>
        public int OfferId { get; set; }

        /// <summary>
        /// Gets or sets the Weight associated with this criteria.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the file type associated with this criteria.
        /// </summary>
        public int FileTypeId { get; set; }
    }
}
