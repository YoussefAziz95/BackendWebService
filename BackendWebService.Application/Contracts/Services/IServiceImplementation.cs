using Application.Contracts.Features;
using Application.Features;
namespace Application.Contracts.Services;

public interface IServiceImplementation
{
    Task<IResponse<int>> AddAsync(AddServiceRequest request);
    Task<IResponse<ServiceResponse>> GetAsync(int id);
    Task<IResponse<string>> DeleteAsync(int id);
    Task<IResponse<int>> UpdateAsync(UpdateServiceRequest request);
    Task<List<ServiceAllResponse>> GetPaginated(ServiceAllRequest request);

}
