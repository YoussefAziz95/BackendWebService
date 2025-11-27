using Domain;

namespace Application.Contracts.Persistence;

public interface IServiceRepository
{
    int UpdateService(Service updatedEntity);
    Service GetById(int id);
}
