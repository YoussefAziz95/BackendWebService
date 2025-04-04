using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Services;
using Application.DTOs.Services.Responses;

namespace Application.Contracts.Services;

public interface IServiceImplementation
{
    Task<IResponse<int>> AddAsync(AddServiceRequest request);
    Task<IResponse<ServiceResponse>> GetAsync(int id);
    Task<IResponse<string>> DeleteAsync(int id);
    Task<IResponse<int>> UpdateAsync(UpdateServiceRequest request);
    Task<PaginatedResponse<GetPaginatedService>> GetPaginated(GetPaginatedRequest request);

}
