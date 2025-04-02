namespace Application.Contracts.Presistence
{
    /// <summary>
    /// Defines the contract for a unit of work, responsible for coordinating multiple repositories.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets a generic repository instance for the specified entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>An instance of the generic repository for the specified entity type.</returns>
        IGenericRepository<T> GenericRepository<T>() where T : class;

        /// <summary>
        /// Saves changes synchronously to the underlying data store.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        int Save();

        /// <summary>
        /// Saves changes asynchronously to the underlying data store.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, returning the number of affected rows.</returns>
        Task<int> SaveAsync();
    }
}
