using Application.DTOs.Logging;

namespace Application.Contracts.Services;

public interface ILoggingService
{
    void Log(LoggingDto loggingDto);
}
