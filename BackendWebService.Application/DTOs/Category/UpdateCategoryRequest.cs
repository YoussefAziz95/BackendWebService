using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Categories
{
    /// <summary>
    /// Represents a request model for updating a category.
    /// </summary>
    public class UpdateCategoryRequest : BaseValidationModel<UpdateCategoryRequest>, ICreateMapper<Category>
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the list of key resource requests representing the name of the category.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent category ID of the category.
        /// </summary>
        public int? ParentId { get; set; }
    }
}
