using Domain;

namespace Application.Contracts.Persistences;

public interface IServiceRepository
{
    Task<int> UpdateService(Service updatedEntity);
    Service GetById(int id);
}
