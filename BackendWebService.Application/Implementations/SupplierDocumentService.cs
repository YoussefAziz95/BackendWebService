using Application.Contracts.DTOs;
using Application.Contracts.Infrastructures;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.SupplierDocuments;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Domain.Constants;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations
{
    /// <summary>
    /// Services for managing supplier documents.
    /// </summary>
    public class SupplierDocumentService : ResponseHandler, ISupplierDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileHandler;
        private readonly ISupplierDocumentRepository _supplierDocumentRepository;

        /// <summary>
        /// Constructor for SupplierDocumentService.
        /// </summary>
        public SupplierDocumentService(IUnitOfWork unitOfWork,
                          IMapper mapper,
                          IFileService fileHandler,
                          ISupplierDocumentRepository supplierDocumentRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileHandler = fileHandler;
            _supplierDocumentRepository = supplierDocumentRepository;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> AddAsync(AddSupplierDocumentRequest request)
        {

            var supplierdocument = _mapper.Map<SupplierDocument>(request);
            var supplierId = _unitOfWork.GenericRepository<Supplier>().Get(c => c.OrganizationId == request.CompanyId).Id;
            var predocument = _unitOfWork.GenericRepository<PreDocument>().Get(c => c.Id == request.PreDocumentId);
            var companyId = _unitOfWork.GenericRepository<Company>().Get(c => c.OrganizationId == predocument.OrganizationId).Id;
            supplierdocument.SupplierAccountId = _unitOfWork.GenericRepository<SupplierAccount>().Get(c => c.SupplierId == supplierId && c.CompanyId == companyId).Id;
            var result = _supplierDocumentRepository.AddSupplierDocumentAsync(supplierdocument);
            return result > 0 ? Created(supplierdocument.Id)
                              : BadRequest<int>("Something went wrong");
        }

        /// <inheritdoc/>
        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<SupplierDocument>()
                                    .Get(b => b.Id == id) is not null;
        }

        /// <inheritdoc/>
        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var supplierdocument = await _unitOfWork.GenericRepository<SupplierDocument>().GetByIdAsync(id);
            _unitOfWork.GenericRepository<SupplierDocument>().Delete(supplierdocument);
            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Deleted<string>()
                              : BadRequest<string>("Something went wrong");
        }

        /// <inheritdoc/>
        public async Task<IResponse<SupplierDocumentResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<SupplierDocumentResponse>();

            var response = GetById(id);

            return Success(response);
        }
        private SupplierDocumentResponse GetById(int id)
        {
            var supplierdocument = GetSupplierDocumentById(id);
            return _mapper.Map<SupplierDocumentResponse>(supplierdocument);

        }
        private SupplierDocument GetSupplierDocumentById(int id)
        {
            return _unitOfWork.GenericRepository<SupplierDocument>()
                .Get(b => b.Id == id, b => b.Include(b => b.PreDocument), disableTracking: false);
        }

        /// <inheritdoc/>
        public async Task<IResponse<List<SupplierDocumentsResponse>>> GetPaginated(int supplierId)
        {
            if (!_supplierDocumentRepository.CheckRegistered(supplierId))
                return BadRequest<List<SupplierDocumentsResponse>>("No Companies Has Resgistered you yet !");
            var paginatedList = _supplierDocumentRepository.GetPaginated(supplierId).ToList();
            return paginatedList.Any() ? Success(paginatedList) : BadRequest<List<SupplierDocumentsResponse>>("No Approval Document Yet !");


        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> UpdateAsync(UpdateSupplierDocumentRequest request)
        {
            try
            {

                var supplierdocument = GetSupplierDocumentById(request.Id);
                supplierdocument.FileId = request.FileId;
                _unitOfWork.GenericRepository<SupplierDocument>().Update(supplierdocument);
                var result = _unitOfWork.Save();

                return result > 0 ? Success(supplierdocument.Id)
                                  : BadRequest<int>("Something went wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        private async Task<string> UploadDocument(string DocUrl, int id, string? oldPath = null!)
        {
            if (oldPath is not null)
                _fileHandler.Delete($"{DocUrl}");
            return _fileHandler.Move(DocUrl, DocUrl.Replace($"{AppConstants.TempUploadPath}", $"{AppConstants.OfferUploadPath}"))
            ? DocUrl.Replace($"{AppConstants.TempUploadPath}", $"{AppConstants.OfferUploadPath}") : DocUrl;
        }




    }
}
