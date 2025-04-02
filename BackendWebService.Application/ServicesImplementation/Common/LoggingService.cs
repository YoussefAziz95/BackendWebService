using Application.Contracts.Presistence;
using Application.Contracts.Services;
using Application.DTOs.Logging;
using AutoMapper;
using Azure.Core;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations.Common
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _loggingRepository;
        private readonly IMapper _mapper;


        public LoggingService(ILoggingRepository loggingRepository, IMapper mapper)
        {
            _loggingRepository = loggingRepository;
            _mapper = mapper;
        }

        public void Log(LoggingDto logDto)
        {
            var log = _mapper.Map<Logging>(logDto);

            _loggingRepository.AddLog(log);
        }
    }
}

