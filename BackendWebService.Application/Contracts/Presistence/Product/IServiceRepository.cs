using Domain;

namespace Application.Contracts.Persistence;

public interface IServiceRepository
{
    Task<int> UpdateService(Service updatedEntity);
    Service GetById(int id);
}
