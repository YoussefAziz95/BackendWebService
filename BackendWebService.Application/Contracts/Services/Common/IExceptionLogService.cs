using Application.Features;
namespace Application.Contracts.Services;

public interface IExceptionLogService
{
    void Add(ExceptionDto request);
}
