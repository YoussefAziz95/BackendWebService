using Application.Contracts.DTOs;
using Application.DTOs.Categories;
using Application.DTOs.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Services interface for category-related operations.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Adds a new category asynchronously.
        /// </summary>
        /// <param name="request">The request containing category details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the added category.</returns>
        Task<IResponse<int>> AddAsync(AddCategoryRequest request);

        /// <summary>
        /// Retrieves a category by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the retrieved category.</returns>
        Task<IResponse<CategoryResponse>> GetAsync(int id);

        /// <summary>
        /// Deletes a category by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of category deletion.</returns>
        Task<IResponse<string>> DeleteAsync(int id);

        /// <summary>
        /// Updates a category asynchronously.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="request">The request containing updated category details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the updated category.</returns>
        Task<IResponse<int>> UpdateAsync(UpdateCategoryRequest request);

        /// <summary>
        /// Retrieves a paginated list of categories asynchronously.
        /// </summary>
        /// <param name="request">The paginated request parameters.</param>
        /// <returns>A task representing the asynchronous operation, returning the paginated response containing the list of categories.</returns>
        Task<IResponse<List<CategoryResponse>>> GetPaginated(int CompanyId);

        /// <summary>
        /// Checks if a category with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the category to check.</param>
        /// <returns>True if the category exists; otherwise, false.</returns>
        bool CheckIdExists(int id);
    }
}
