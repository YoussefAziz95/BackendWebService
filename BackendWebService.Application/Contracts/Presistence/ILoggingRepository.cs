
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Presistence
{
    public interface ILoggingRepository
    {
        void AddLog(Logging log);
    }
}
