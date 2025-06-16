using Application.Features;
using Application.Features;
using Domain;

namespace Application.Contracts.Persistence;

public interface ICompanyRepository : IOrganizationRepository<Company, CompanyResponse, CompanyAllResponse>
{
    int Add(Company entity);
}

