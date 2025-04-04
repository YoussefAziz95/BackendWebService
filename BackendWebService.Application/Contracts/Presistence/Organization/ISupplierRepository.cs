
using Application.DTOs.Suppliers;
using Domain;

namespace Application.Contracts.Persistences;

public interface ISupplierRepository
{
    Task<int> AddAsync(Supplier supplier, User user, string generateRandomPassword);
    Task<int> Register(int supplierId);
    bool Delete(int id);
    List<GetPaginatedSupplier> GetPaginated(int CompanyId);
    bool CheckIdExists(int id);
    int Update(Supplier entity);
    Supplier GetById(int id);
    List<GetPaginatedSupplier> GetRegisteredSupplier();
}
