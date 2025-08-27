using Application.Contracts.Features;
using Application.Features;
namespace Application.Contracts.Services
{
    public interface ISupplierService
    {
        Task<IResponse<int>> AddUnregisteredAsync(AddSupplierRequest request);
        Task<IResponse<SupplierResponse>> GetAsync(int id);
        Task<IResponse<int>> UpdateAsync(UpdateSupplierRequest request);
        Task<PaginatedResponse<GetPaginatedSupplier>> GetPaginated(GetPaginatedCommon request);
        bool CheckIdExists(int id);
        Task<IResponse<int>> AddRegisteredAsync(AddSupplierRequest request);
        Task<IResponse<int>> RegisterAsync(int supplierId);
        Task<IResponse<string>> DeleteAsync(int id);
        Task<PaginatedResponse<GetPaginatedSupplier>> GetRegisterSuppliers(GetPaginatedCommon request);
        Task<IResponse<int>> AddSupplierTOCompany(AddSupplierToCompany request);

    }
}
