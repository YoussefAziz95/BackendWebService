using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Service;
using Application.DTOs.Service.Responses;

namespace Application.Contracts.Services
{
    public interface IServiceService
    {
        Task<IResponse<int>> AddAsync(AddServiceRequest request);

        Task<IResponse<ServiceResponse>> GetAsync(int id);

        Task<IResponse<string>> DeleteAsync(int id);

        Task<IResponse<int>> UpdateAsync(UpdateServiceRequest request);

        Task<IResponse<GetPaginatedService>> GetPaginated(GetPaginatedRequest request);


    }
}
