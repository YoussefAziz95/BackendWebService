using Domain;

namespace Application.Contracts.Persistence;
public interface ILoggingRepository
{
    void AddLog(Logging log);
}
