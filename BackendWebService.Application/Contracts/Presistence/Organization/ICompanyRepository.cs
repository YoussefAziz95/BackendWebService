using Application.DTOs.Supplier.Responses;

using Application.DTOs.Company.Response;

namespace Application.Contracts.Presistence.Organization
{

    /// <summary>
    /// Defines the repository interface for managing organizations.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being managed.</typeparam>
    /// <typeparam name="TResponse">The type of the response for a single entity.</typeparam>
    /// <typeparam name="TResponses">The type of the response for multiple entities or paginated results.</typeparam>
    public interface ICompanyRepository : IOrganizationRepository<Company,CompanyResponse,GetPaginatedCompany> 
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The number of records affected or the entity ID.</returns>
        int Add(Company entity);

    }

}
