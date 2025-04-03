
using Application.DTOs.Suppliers.Responses;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.Organizations
{

    /// <summary>
    /// Defines the repository interface for managing organizations.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being managed.</typeparam>
    /// <typeparam name="TResponse">The type of the response for a single entity.</typeparam>
    /// <typeparam name="TResponses">The type of the response for multiple entities or paginated results.</typeparam>
    public interface ISupplierRepository
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The number of records affected or the entity ID.</returns>
        Task<int> AddAsync(Supplier supplier, User user, string generateRandomPassword);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The number of records affected or the entity ID.</returns>
        Task<int> Register(int supplierId);


        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        bool Delete(int id);


        /// <summary>
        /// Retrieves a paginated list of entities.
        /// </summary>
        /// <returns>An IQueryable of entity responses.</returns>
        List<GetPaginatedSupplier> GetPaginated(int CompanyId);

        /// <summary>
        /// Checks if an entity with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the entity to check.</param>
        /// <returns>True if the entity exists, otherwise false.</returns>
        bool CheckIdExists(int id);
        int Update(Supplier entity);

        Supplier GetById(int id);

        List<GetPaginatedSupplier> GetRegisteredSupplier();
    }

}
