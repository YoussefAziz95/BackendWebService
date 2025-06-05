using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using AutoMapper;

namespace Application.Implementations.Common
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _loggingRepository;
        


        public LoggingService(ILoggingRepository loggingRepository, IMapper mapper)
        {
            _loggingRepository = loggingRepository;
        }

        public void Log(Logger logDto)
        {
            var log = new Logging()
            {
                Message = logDto.Message,
                LogType = logDto.LogType,
                Suggestion = logDto.Suggestion,
                SourceLayer = logDto.SourceLayer,
                SourceClass = logDto.SourceClass,
                SourceLineNumber = logDto.SourceLineNumber,
                UserId = logDto.UserId,
                Timestamp = DateTime.UtcNow
            };

            _loggingRepository.AddLog(log);
        }
    }
}

