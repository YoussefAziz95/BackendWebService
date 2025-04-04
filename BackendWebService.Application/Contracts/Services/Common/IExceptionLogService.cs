using Application.DTOs.ExceptionLogs;

namespace Application.Contracts.Services;

public interface IExceptionLogService
{
    void Add(ExceptionDto request);
}
