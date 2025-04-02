using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.PreDocument;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Service interface for pre document-related operations.
    /// </summary>
    public interface IPreDocumentService
    {
        /// <summary>
        /// Adds a new pre document asynchronously.
        /// </summary>
        /// <param name="request">The request containing pre document details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the added pre document.</returns>
        Task<IResponse<PreDocumentResponse>> AddAsync(AddPreDocumentRequest request);

        /// <summary>
        /// Retrieves a pre document by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the pre document to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the retrieved pre document.</returns>
        Task<IResponse<PreDocumentResponse>> GetAsync(int id);

        /// <summary>
        /// Deletes a pre document by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the pre document to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of pre document deletion.</returns>
        Task<IResponse<string>> DeleteAsync(int id);

        /// <summary>
        /// Updates a pre document asynchronously.
        /// </summary>
        /// <param name="id">The ID of the pre document to update.</param>
        /// <param name="request">The request containing updated pre document details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the updated pre document.</returns>
        Task<IResponse<PreDocumentResponse>> UpdateAsync(int id, UpdatePreDocumentRequest request);

        /// <summary>
        /// Retrieves a paginated list of pre documents asynchronously.
        /// </summary>
        /// <param name="request">The paginated request parameters.</param>
        /// <returns>A task representing the asynchronous operation, returning the paginated response containing the list of pre documents.</returns>
        Task<IResponse<PreDocumentResponse>> GetPaginated(GetPaginatedRequest request);

        /// <summary>
        /// Retrieves all pre documents asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, returning the response containing the list of all pre documents.</returns>
        Task<IResponse<IEnumerable<PreDocumentResponse>>> GetAllAsync();

        /// <summary>
        /// Checks if a pre document with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the pre document to check.</param>
        /// <returns>True if the pre document exists; otherwise, false.</returns>
        bool CheckIdExists(int id);
    }
}
