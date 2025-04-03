using Domain;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.Product
{
    public interface IServiceRepository
    {
        Task<int> UpdateService(Service updatedEntity);
        Service GetById(int id);
    }
}
