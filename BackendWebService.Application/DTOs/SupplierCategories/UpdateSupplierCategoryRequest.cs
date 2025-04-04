using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;

namespace Application.DTOs.SupplierCategories
{
    /// <summary>
    /// Represents a request model for updating a supplier's category.
    /// </summary>
    public class UpdateSupplierCategoryRequest : BaseValidationModel<UpdateSupplierCategoryRequest>, ICreateMapper<SupplierCategory>
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
