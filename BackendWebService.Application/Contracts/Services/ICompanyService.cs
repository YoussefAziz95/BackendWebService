using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Companies;
using Application.DTOs.Companies;
using Application.DTOs.Suppliers;

namespace Application.Contracts.Services;

public interface ICompanyService
{
    Task<IResponse<int>> AddAsync(AddCompanyRequest request);

    Task<IResponse<string>> DeleteAsync(int id);

    Task<IResponse<CompanyResponse>> GetAsync(int id);

    Task<IResponse<int>> UpdateAsync(UpdateCompanyRequest request);

    Task<PaginatedResponse<GetPaginatedCompany>> GetPaginated(GetPaginatedRequest request);

    bool CheckIdExists(int id);
}
