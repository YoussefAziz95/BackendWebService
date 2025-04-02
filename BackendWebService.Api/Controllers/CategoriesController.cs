using Application.Contracts.Services;
using Application.DTOs.Category;
using Application.DTOs.Common;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller to manage category-related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : AppControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="categoryService">The category service.</param>
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="request">The request containing category details.</param>
        /// <returns>A response indicating the result of the add operation.</returns>
        [HttpPost]
        [Authorize(PermissionConstants.CATEGORY_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            var result = await _categoryService.AddAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets a category by ID.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <returns>A response containing the category details.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.CATEGORY_GET)]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var result = await _categoryService.GetAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        [HttpDelete("{id}")]
        [Authorize(PermissionConstants.CATEGORY_DELETE)]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates a category by ID.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <param name="request">The request containing updated category details.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        [HttpPut]
        [Authorize(PermissionConstants.CATEGORY_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> UpdateCategory( [FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateAsync( request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets all categories with pagination.
        /// </summary>
        /// <param name="request">The request containing pagination details.</param>
        /// <returns>A response containing the paginated list of categories.</returns>
        [HttpGet("GetAll/{CompanyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromRoute] int CompanyId)
        {
            var result = await _categoryService.GetPaginated(CompanyId);
            return Ok(result);
        }

    }
}
