using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.DTOs.Logging;
using AutoMapper;
using Domain;

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

