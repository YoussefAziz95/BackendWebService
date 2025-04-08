using Application.DTOs.Loggings;

namespace Application.Contracts.Services;

public interface ILoggingService
{
    void Log(LoggingDto loggingDto);
}
