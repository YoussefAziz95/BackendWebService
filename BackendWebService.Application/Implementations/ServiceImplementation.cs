using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Features.Common;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Domain.Constants;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations
{
    public class ServiceImplementation : ResponseHandler, IServiceImplementation
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceRepository _materialRepository;

        public ServiceImplementation(IUnitOfWork unitOfWork, IMapper mapper, IServiceRepository materialRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _materialRepository = materialRepository;
        }
        public async Task<IResponse<int>> AddAsync(AddServiceRequest request)
        {

            var matetial = _mapper.Map<AddServiceRequest, Service>(request);

            await _unitOfWork.GenericRepository<Service>().AddAsync(matetial);

            var result = await _unitOfWork.SaveAsync();
            return result > 0 ? Created(matetial.Id)
                              : BadRequest<int>("Something went wrong");
        }

        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var material = await _unitOfWork.GenericRepository<Service>().GetByIdAsync(id);

            _unitOfWork.GenericRepository<Service>().Delete(material);



            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Deleted<string>()
                              : BadRequest<string>("Something went wrong");
        }

        public async Task<IResponse<ServiceResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<ServiceResponse>();

            var response = GetById(id);

            return Success(response);
        }

        public async Task<PaginatedResponse<GetPaginatedService>> GetPaginated(GetPaginatedRequest request)
        {

            IQueryable<GetPaginatedService> materials = _unitOfWork.GenericRepository<Service>()?
                       .GetAll()?.Select(t => new GetPaginatedService(t.Id, t.Code, t.Name))?.AsQueryable();

            var paginatedList = materials
                        .ToPaginatedList((int)request.PageNumber!, (int)request.PageSize!);
            return paginatedList;
        }

        public async Task<IResponse<int>> UpdateAsync(UpdateServiceRequest request)
        {
            var oldService = _mapper.Map<UpdateServiceRequest, Service>(request);

            var result = await _materialRepository.UpdateService(oldService);


            return result > 0 ? Success(result)
                              : BadRequest<int>("Something went wrong");
        }
        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<Service>()
                        .ExistsNoTracking(b => b.Id == id);
        }
        private ServiceResponse GetById(int id)
        {
            var service = _unitOfWork.GenericRepository<Service>()
                           .Get(c => c.Id == id, include: c => c.Include(m => m.Category));
            var response = new ServiceResponse(service.Id, service.Name, service.Code, service.Category.Name);

            return response;
        }
    }
}
