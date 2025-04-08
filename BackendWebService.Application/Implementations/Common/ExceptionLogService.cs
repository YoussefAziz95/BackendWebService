using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.ExceptionLogs;
using Application.Wrappers;
using AutoMapper;
using Domain;


namespace Application.Implementations.Common;

public class ExceptionLogService : IResponseHandler, IExceptionLogService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ExceptionLogService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public void Add(ExceptionDto request)
    {
        var exception = _mapper.Map<ExceptionLog>(request); ;
        _unitOfWork.GenericRepository<ExceptionLog>().AddAsync(exception);
        _unitOfWork.SaveAsync();
    }
}
