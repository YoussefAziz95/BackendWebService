using Application.DTOs.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface ILoggingService
    {
        void Log(LoggingDto loggingDto);
    }
}
