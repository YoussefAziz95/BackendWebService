using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.SupplierDocument;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Defines operations for managing supplier documents.
    /// </summary>
    public interface ISupplierDocumentService
    {
        /// <summary>
        /// Adds a new supplier document asynchronously.
        /// </summary>
        /// <param name="request">The request containing information about the supplier document to be added.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with the ID of the created supplier document.</returns>
        Task<IResponse<int>> AddAsync(AddSupplierDocumentRequest request);

        /// <summary>
        /// Retrieves information about a supplier document asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier document to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with information about the supplier document.</returns>
        Task<IResponse<SupplierDocumentResponse>> GetAsync(int id);

        /// <summary>
        /// Deletes a supplier document asynchronously.
        /// </summary>
        /// <param name="id">The ID of the supplier document to delete.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with a message indicating the outcome of the operation.</returns>
        Task<IResponse<string>> DeleteAsync(int id);

        /// <summary>
        /// Updates an existing supplier document asynchronously.
        /// </summary>
        /// <param name="id">The ID of the supplier document to update.</param>
        /// <param name="request">The request containing updated information about the supplier document.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with the ID of the updated supplier document.</returns>
        Task<IResponse<int>> UpdateAsync(UpdateSupplierDocumentRequest request);

        /// <summary>
        /// Retrieves a paginated list of supplier documents.
        /// </summary>
        /// <param name="ComId">The ID of the company associated with the supplier documents.</param>
        /// <param name="request">The request containing pagination parameters.</param>
        /// <returns>The paginated response containing information about supplier documents.</returns>
        Task<IResponse<List<SupplierDocumentsResponse>>>  GetPaginated(int supplierId);


        /// <summary>
        /// Checks if a supplier document ID exists.
        /// </summary>
        /// <param name="id">The ID of the supplier document to check.</param>
        /// <returns>True if the supplier document ID exists; otherwise, false.</returns>
        bool CheckIdExists(int id);
    }
}
