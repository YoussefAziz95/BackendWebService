using Application.Contracts.Features;
using Application.Features.Common;
using Application.Features;
using Application.Features;
using Application.Features;

namespace Application.Contracts.Services;

public interface ICompanyService
{
    Task<IResponse<int>> AddAsync(AddCompanyRequest request);

    Task<IResponse<string>> DeleteAsync(int id);

    Task<IResponse<CompanyResponse>> GetAsync(int id);

    Task<IResponse<int>> UpdateAsync(UpdateCompanyRequest request);

    Task<PaginatedResponse<CompanyAllResponse>> GetPaginated(GetPaginatedCompanyRequest request);

    bool CheckIdExists(int id);
}
