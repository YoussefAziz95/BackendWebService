using Application.Contracts.Features;
using Application.Features;
using Application.Features.Common;

namespace Application.Contracts.Services;

public interface IServiceImplementation
{
    Task<IResponse<int>> AddAsync(AddServiceRequest request);
    Task<IResponse<ServiceResponse>> GetAsync(int id);
    Task<IResponse<string>> DeleteAsync(int id);
    Task<IResponse<int>> UpdateAsync(UpdateServiceRequest request);
    Task<PaginatedResponse<GetPaginatedService>> GetPaginated(GetPaginatedRequest request);

}
