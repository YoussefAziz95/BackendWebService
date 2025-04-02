
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Presistence.Product
{
    public interface IServiceRepository
    {
        Task<int> UpdateService(Service updatedEntity);
        Service GetById(int id);
    }
}
