using Application.Features;
using Domain;

namespace Application.Contracts.Persistence;

public interface ISupplierRepository
{
    Task<int> AddAsync(Supplier supplier, User user, string generateRandomPassword);
    Task<int> Register(int supplierId);
    bool Delete(int id);
    List<GetPaginatedSupplier> GetPaginated();
    bool CheckIdExists(int id);
    int Update(Supplier entity);
    Supplier GetById(int id);
    List<GetPaginatedSupplier> GetRegisteredSupplier();
}
