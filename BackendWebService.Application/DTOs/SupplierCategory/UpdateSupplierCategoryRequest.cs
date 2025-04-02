using Application.Validators.Common;

namespace Application.DTOs.SupplierCategory
{
    /// <summary>
    /// Represents a request model for updating a supplier's category.
    /// </summary>
    public class UpdateSupplierCategoryRequest : BaseValidationModel<UpdateSupplierCategoryRequest>
    {
        /// <summary>
        /// Gets or sets the ID of the company associated with the category.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
