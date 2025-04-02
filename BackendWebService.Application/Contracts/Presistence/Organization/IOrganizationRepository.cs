
using Application.DTOs.Supplier.Responses;


namespace Application.Contracts.Presistence.Organization
{

    /// <summary>
    /// Defines the repository interface for managing organizations.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being managed.</typeparam>
    /// <typeparam name="TResponse">The type of the response for a single entity.</typeparam>
    /// <typeparam name="TResponses">The type of the response for multiple entities or paginated results.</typeparam>
    public interface IOrganizationRepository<TEntity, TResponse, TResponses>
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The number of records affected or the entity ID.</returns>
        int Add(TEntity entity);
        int Update(TEntity entity);

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        bool Delete(int id);

        /// <summary>
        /// Retrieves a single entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity response.</returns>
        TResponse GetResponse(int id);

        /// <summary>
        /// Retrieves a paginated list of entities.
        /// </summary>
        /// <returns>An IQueryable of entity responses.</returns>
        IQueryable<TResponses> GetPaginated();

        /// <summary>
        /// Checks if an entity with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the entity to check.</param>
        /// <returns>True if the entity exists, otherwise false.</returns>
        bool CheckIdExists(int id);
    }

}
