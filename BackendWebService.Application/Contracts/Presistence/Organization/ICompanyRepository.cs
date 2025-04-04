using Application.DTOs.Companies;
using Application.DTOs.Suppliers;

namespace Application.Contracts.Persistences;

public interface ICompanyRepository : IOrganizationRepository<Company, CompanyResponse, GetPaginatedCompany>
{
    int Add(Company entity);
}
