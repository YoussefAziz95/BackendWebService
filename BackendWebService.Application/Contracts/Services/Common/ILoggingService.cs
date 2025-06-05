using Application.Features;

namespace Application.Contracts.Services;

public interface ILoggingService
{
    void Log(Logger loggingDto);
}
