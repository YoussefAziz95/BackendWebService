using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Wrappers;
using AutoMapper;
using Domain;


namespace Application.Implementations.Common;

public class ExceptionLogService : ResponseHandler, IExceptionLogService
{
    
    private readonly IUnitOfWork _unitOfWork;

    public ExceptionLogService( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(ExceptionDto request)
    {
        var exception = new Logging()
        {
            ExceptionCode = request.ExceptionCode,
            KeyExceptionMessage = request.KeyExceptionMessage,
        };
        _unitOfWork.GenericRepository<Logging>().AddAsync(exception);
        _unitOfWork.SaveAsync();
    }
}
