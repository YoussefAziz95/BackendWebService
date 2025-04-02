using Application.Contracts.DTOs;
using Application.DTOs.Auth.Request;
using Application.DTOs.Common;
using Application.DTOs.Supplier.Request;
using Application.DTOs.Supplier.Responses;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Interface for supplier-related services.
    /// </summary>
    public interface ISupplierService
    {
        /// <summary>
        /// Adds a new supplier asynchronously.
        /// </summary>
        /// <param name="request">The request containing supplier details.</param>
        /// <returns>A response containing the ID of the added supplier.</returns>
        Task<IResponse<int>> AddUnregisteredAsync(AddSupplierRequest request);

        /// <summary>
        /// Retrieves a supplier asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier.</param>
        /// <returns>A response containing the supplier details.</returns>
        Task<IResponse<SupplierResponse>> GetAsync(int id);

        /// <summary>
        /// Updates a supplier asynchronously.
        /// </summary>
        /// <param name="id">The ID of the supplier to update.</param>
        /// <param name="request">The request containing updated supplier details.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        Task<IResponse<int>> UpdateAsync(UpdateSupplierRequest request);

        /// <summary>
        /// Retrieves a paginated list of suppliers asynchronously.
        /// </summary>
        /// <param name="request">The request containing pagination details.</param>
        /// <returns>A paginated response containing the list of suppliers.</returns>
        Task<IResponse<GetPaginatedSupplier>> GetPaginated(GetPaginatedRequest request);

        /// <summary>
        /// Checks if a supplier with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the supplier.</param>
        /// <returns>True if the supplier exists; otherwise, false.</returns>
        bool CheckIdExists(int id);

        /// <summary>
        /// Registers a new supplier asynchronously.
        /// </summary>
        /// <param name="request">The request containing supplier registration details.</param>
        /// <returns>A response containing the ID of the registered supplier.</returns>
        Task<IResponse<int>> AddRegisteredAsync(AddSupplierRequest request);
        Task<IResponse<int>> RegisterAsync(int supplierId);

        /// <summary>
        /// Deletes a supplier asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        Task<IResponse<string>> DeleteAsync(int id);
        Task<IResponse<GetPaginatedSupplier>> GetRegisterSuppliers(GetPaginatedRequest request);
        Task<IResponse<int>> AddSupplierTOCompany( AddSupplierToCompany request);

    }
}
