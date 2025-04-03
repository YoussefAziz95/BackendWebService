using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Companies.Request;
using Application.DTOs.Companies.Response;
using Application.DTOs.Suppliers.Responses;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Defines operations for managing companies.
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Adds a new company asynchronously.
        /// </summary>
        /// <param name="request">The request containing information about the company to be added.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with the ID of the created company.</returns>
        Task<IResponse<int>> AddAsync(AddCompanyRequest request);

        /// <summary>
        /// Deletes a company asynchronously.
        /// </summary>
        /// <param name="id">The ID of the company to delete.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with a message indicating the outcome of the operation.</returns>
        Task<IResponse<string>> DeleteAsync(int id);

        /// <summary>
        /// Retrieves information about a company asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the company to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with information about the company.</returns>
        Task<IResponse<CompanyResponse>> GetAsync(int id);

        /// <summary>
        /// Updates an existing company asynchronously.
        /// </summary>
        /// <param name="id">The ID of the company to update.</param>
        /// <param name="request">The request containing updated information about the company.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with the ID of the updated company.</returns>
        Task<IResponse<int>> UpdateAsync(UpdateCompanyRequest request);

        /// <summary>
        /// Retrieves a paginated list of companies.
        /// </summary>
        /// <param name="request">The request containing pagination parameters.</param>
        /// <returns>The paginated response containing information about companies.</returns>
        Task<PaginatedResponse<GetPaginatedCompany>> GetPaginated(GetPaginatedRequest request);

        /// <summary>
        /// Checks if a company ID exists.
        /// </summary>
        /// <param name="id">The ID of the company to check.</param>
        /// <returns>True if the company ID exists; otherwise, false.</returns>
        bool CheckIdExists(int id);
    }
}
