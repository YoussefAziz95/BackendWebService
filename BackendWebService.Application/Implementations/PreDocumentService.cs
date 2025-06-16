using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features.Common;
using Application.Features;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Application.Implementations
{
    public class PreDocumentService : ResponseHandler, IPreDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PreDocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResponse<PreDocumentResponse>> AddAsync(AddPreDocumentRequest request)
        {


            var company = GetCompany((int)request.UserId);

            if (company is null)
                return BadRequest<PreDocumentResponse>("Customer Doesnt Belong to a Companies");
            if (CheckNameExists(request.Name))
                return BadRequest<PreDocumentResponse>("Document Name Already Exist");
            var PreDocument = _mapper.Map<PreDocument>(request);
            await _unitOfWork.GenericRepository<PreDocument>().AddAsync(PreDocument);
            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Created(_mapper.Map<PreDocumentResponse>(PreDocument))
                              : BadRequest<PreDocumentResponse>("Something went wrong");
        }

        public bool CheckNameExists(string name)
        {
            return _unitOfWork.GenericRepository<PreDocument>().Exists(d => d.Name == name);
        }

        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<PreDocument>()
                        .Get(b => b.Id == id) is not null;
        }

        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var PreDocument = await _unitOfWork.GenericRepository<PreDocument>().GetByIdAsync(id);
            _unitOfWork.GenericRepository<PreDocument>().SoftDelete(PreDocument);
            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Deleted<string>()
                              : BadRequest<string>("Something went wrong");
        }

        public async Task<IResponse<IEnumerable<PreDocumentResponse>>> GetAllAsync()
        {
            var PreDocuments = _unitOfWork.GenericRepository<PreDocument>().GetAll().AsQueryable();
            var docTypeResponse = _mapper.ProjectTo<PreDocumentResponse>(PreDocuments).AsEnumerable();

            return Success(docTypeResponse);
        }

        public async Task<IResponse<PreDocumentResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<PreDocumentResponse>();

            var response = GetById(id);

            return Success(response);
        }

        public async Task<PaginatedResponse<PreDocumentResponse>> GetPaginated(GetPaginatedRequest request)
        {

            var PreDocuments = _unitOfWork.GenericRepository<PreDocument>()
                       .GetAll()
                       .AsQueryable();

            var paginatedList = _mapper.ProjectTo<PreDocumentResponse>(PreDocuments)
                                .ToPaginatedList((int)request.PageNumber!, (int)request.PageSize!);
            return paginatedList;
        }

        public async Task<IResponse<PreDocumentResponse>> UpdateAsync(int id, UpdatePreDocumentRequest request)
        {
            if (!CheckIdExists(id))
                return NotFound<PreDocumentResponse>();


            var roleType = _mapper.Map<PreDocument>(request);
            var updatedPreDocument = _unitOfWork.GenericRepository<PreDocument>().Update(id, roleType);
            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Success(GetById(id))
                              : BadRequest<PreDocumentResponse>("Something went wrong");
        }
        private Company GetCompany(int id)
        {
            var result = _unitOfWork.GenericRepository<User>().Get(u => u.Id == id,
                   include: d => d.Include(c => c.Organization));

            return _unitOfWork.GenericRepository<Company>().Get(c => c.OrganizationId == result.OrganizationId);
        }

        private PreDocumentResponse GetById(int id)
        {
            var roleType = _unitOfWork.GenericRepository<PreDocument>()
                            .Get(b => b.Id == id);
            return _mapper.Map<PreDocumentResponse>(roleType);
        }
    }
}
