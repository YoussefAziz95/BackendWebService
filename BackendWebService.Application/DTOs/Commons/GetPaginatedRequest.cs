namespace Application.DTOs.Common
{
    /// <summary>
    /// Represents a request model for pagination.
    /// </summary>
    public class GetPaginatedRequest
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int? pageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int? pageSize { get; set; }

        /// <summary>
        /// Gets or sets the filter criteria.
        /// </summary>
        public string? filterBy { get; set; }

        /// <summary>
        /// Gets or sets the sorting criteria.
        /// </summary>
        public string? sortBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sorting is in descending order.
        /// </summary>
        public bool sortDescending { get; set; } = default;

        /// <summary>
        /// Gets or sets the company ID.
        /// </summary>
        public int? CompanyId { get; set; }
    }
}
