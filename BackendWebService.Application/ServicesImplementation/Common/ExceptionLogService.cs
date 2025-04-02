using Application.Contracts.Presistence;
using Application.Contracts.Services;
using Application.DTOs.ExceptionLog;
using Application.MappingProfiles;
using Application.Wrappers;
using AutoMapper;


namespace Application.Implementations.Common
{
    public class ExceptionLogService : ResponseHandler, IExceptionLogService
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
}
