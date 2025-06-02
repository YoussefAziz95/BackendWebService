using Application.Validators.Common;
using Application.Profiles;
using Domain;

namespace Application.DTOs.SupplierCategories
{
    /// <summary>
    /// Represents a request to update a range of supplier categories.
    /// </summary>
    public class UpdateRangeSupplierCategoryRequest : BaseValidationModel<UpdateRangeSupplierCategoryRequest>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the supplier category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the company associated with the supplier category.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the category associated with the supplier.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the supplier category is marked as deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
