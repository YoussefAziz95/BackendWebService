using Application.Features;
using Application.Features;
using Domain;

namespace Application.Contracts.Persistence;

public interface ICompanyRepository : IOrganizationRepository<Company, CompanyResponse, GetPaginatedCompany>
{
    int Add(Company entity);
}

