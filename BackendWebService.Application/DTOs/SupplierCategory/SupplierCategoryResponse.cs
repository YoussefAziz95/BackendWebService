namespace Application.DTOs.SupplierCategory
{
    /// <summary>
    /// Represents a response model for supplier categories.
    /// </summary>
    public class SupplierCategoryResponse
    {
        /// <summary>
        /// Gets or sets the ID of the supplier category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company associated with the supplier category.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the category associated with the supplier category.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
