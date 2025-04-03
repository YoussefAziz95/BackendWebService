using Application.Contracts.DTOs;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Product;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Services;
using Application.DTOs.Services.Responses;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Domain.Constants;
using System.Linq;
using System.Threading.Tasks;

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

            var matetial = _mapper.Map<AddServiceRequest,Service>(request);

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

            string sortExpression = string.IsNullOrEmpty(request.sortBy) ?
                                        $"Id {(request.sortDescending ? AppConstants.descending : AppConstants.ascending)}" :
            $"{request.sortBy} {(request.sortDescending ? AppConstants.descending : AppConstants.ascending)}";
            IQueryable<GetPaginatedService> materials = _unitOfWork.GenericRepository<Service>()?
                       .GetAll()?.Select(t => new GetPaginatedService
                       {
                           Id = t.Id,
                           Code = t.Code,
                           Name = t.Name,

                       }).AsQueryable();

            var paginatedList = materials
                        .ToPaginatedList((int)request.pageNumber!, (int)request.pageSize!);
            return paginatedList;
        }

        public async Task<IResponse<int>> UpdateAsync(UpdateServiceRequest request)
        {
            var oldService = _mapper.Map<UpdateServiceRequest,Service>(request);

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
            var material = _unitOfWork.GenericRepository<Service>()
                           .Get(c => c.Id == id);
            var response = new ServiceResponse
            {
                Id = material.Id,
                Name = material.Name,
                Code = material.Code,
                CategoryId = material.CategoryId,

            };

            return response;
        }
    }
}
