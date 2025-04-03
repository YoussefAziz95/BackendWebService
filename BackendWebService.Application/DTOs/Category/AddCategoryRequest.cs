using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Categories
{
    /// <summary>
    /// Request model for adding a category.
    /// </summary>
    public class AddCategoryRequest : BaseValidationModel<AddCategoryRequest>, ICreateMapper<Category>
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent category, if any.
        /// </summary>
        public int? ParentId { get; set; }
    }
}
