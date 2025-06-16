using Application.Contracts.Features;
using Application.Contracts.Infrastructures;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Features.Common;
using Application.Model.EmailDto;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Domain;
using Domain.Constants;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Cryptography;

namespace Application.Implementations
{
    /// <summary>
    /// Services implementation for managing suppliers.
    /// </summary>
    public class SupplierService : ResponseHandler, ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="roleTypeService"></param>
        /// <param name="fileHandler"></param>
        /// <param name="keyRescourcesService"></param>
        /// <param name="applicationUserService"></param>
        /// <param name="emailService"></param>
        /// <param name="supplierRepository"></param>
        /// <param name="authService"></param>
        public SupplierService(IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IEmailService emailService,
                             ISupplierRepository supplierRepository)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _supplierRepository = supplierRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Adds a new supplier.
        /// </summary>
        private async Task<IResponse<int>> AddAsync(AddSupplierRequest request)
        {
            if (_unitOfWork.GenericRepository<Organization>().Exists(c => c.Email == request.Email)
              || _unitOfWork.GenericRepository<User>().Exists(c => c.Email == request.Email))
                return BadRequest<int>("EmailDto Already Exist!");

            var supplier = _mapper.Map<Supplier>(request);
            supplier.Organization = _mapper.Map<Organization>(request);
            var user = _mapper.Map<User>(supplier);
            user = _mapper.Map<User>(request);

            var generateRandomPassword = GenerateRandomPassword();

            supplier.Id = await _supplierRepository.AddAsync(supplier, user, generateRandomPassword);
            try
            {
                var subject = "Suppliers " + supplier.Organization.Name + " Created";
                var body = " with email = " + user.Email + " and with password = " + generateRandomPassword;
                var emailDto = new EmailDto(subject, body, supplier.Organization.Email, "", "", DateTime.Now, 1);
                var emailSent = await _emailService.Send(emailDto);
                await _unitOfWork.SaveAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Success(supplier.Id);
        }
        public async Task<IResponse<int>> AddUnregisteredAsync(AddSupplierRequest request)
        {

            if (_unitOfWork.GenericRepository<Organization>().Exists(c => c.Email == request.Email)
              || _unitOfWork.GenericRepository<User>().Exists(c => c.Email == request.Email))
                return BadRequest<int>("EmailDto Already Exist!");

            var result = await AddAsync(request);

            return result;
        }
        /// <summary>
        /// Registers a new supplier.
        /// </summary>
        public async Task<IResponse<int>> AddRegisteredAsync(AddSupplierRequest request)
        {
            if (_unitOfWork.GenericRepository<Organization>().Exists(c => c.Email == request.Email)
                  || _unitOfWork.GenericRepository<User>().Exists(c => c.Email == request.Email))
                return BadRequest<int>("EmailDto Already Exist!");
            var result = await AddAsync(request);
            var id = result.Data;
            var response =  _supplierRepository.Register(id);
            return response.Status > 0 ? Success(id) : BadRequest<int>("Failed to Add Registered Account");

        }

        public async Task<IResponse<int>> RegisterAsync(int supplierId)
        {
            var result = await _supplierRepository.Register(supplierId);
            return Created(result);
        }

        /// <summary>
        /// Checks if a supplier with the given ID exists.
        /// </summary>
        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<Supplier>()
                        .ExistsNoTracking(b => b.Id == id);
        }

        /// <summary>
        /// Retrieves a supplier by its ID.
        /// </summary>
        public async Task<IResponse<SupplierResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<SupplierResponse>();
            var supplier = _supplierRepository.GetById(id);
            var response = new SupplierResponse
            (
                Id: supplier.Id,
                Name: supplier.Organization.Name,
                Country: supplier.Organization.Country!,
                City: supplier.Organization.City!,
                StreetAddress: supplier.Organization.StreetAddress!,
                Email: supplier.Organization.Email!,
                TaxNo: supplier.Organization.TaxNo,
                Phone: supplier.Organization.Phone,
                FileId: supplier.Organization.FileId!,
                ImageUrl: null,
                Fax: supplier.Organization.FaxNo,
                ApprovedDate: null,
                IsDocumentsApproved: false,
                IsApproved: false,
                Categories: supplier.SupplierCategories?
                    .Select(c => new SupplierCategoryResponse(supplier.Id, c.CategoryId)).ToList(),
                Department: null,
                Title: null
            );
            return Success(response);
        }


        /// <summary>
        /// Retrieves paginated list of suppliers.
        /// </summary>
        public async Task<PaginatedResponse<GetPaginatedSupplier>> GetPaginated(GetPaginatedRequest request)
        {
            var paginatedList = _supplierRepository.GetPaginated().AsQueryable()
                        .ToPaginatedList(1, (int)request.PageSize!);
            return paginatedList;
        }

        public async Task<PaginatedResponse<GetPaginatedSupplier>> GetRegisterSuppliers(GetPaginatedRequest request)
        {
            var paginatedList = _supplierRepository.GetRegisteredSupplier().AsQueryable()
                        .ToPaginatedList(1, (int)request.PageSize!);
            return paginatedList;
        }
        public async Task<IResponse<int>> AddSupplierTOCompany(AddSupplierToCompany request)
        {
            var Temp = new SupplierAccount()
            {
                CompanyId = request.CompanyId,
                SupplierId = request.SupplierId,
            };
            try
            {
                _unitOfWork.GenericRepository<SupplierAccount>().AddAsync(Temp);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {

            }



            return Created(Temp.Id);
        }


        /// <summary>
        /// Updates an existing supplier.
        /// </summary>
        public async Task<IResponse<int>> UpdateAsync(UpdateSupplierRequest request)
        {
            var oldsupplier = _mapper.Map<Supplier>(request);
            oldsupplier.Organization = _mapper.Map<Organization>(request);
            try
            {
                oldsupplier.Id = _supplierRepository.Update(oldsupplier);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return oldsupplier is not null ? Success(oldsupplier.Id)
                              : BadRequest<int>("Something went wrong");
        }

        private SupplierResponse GetById(int id)
        {
            var supplier = _supplierRepository.GetById(id);

            return new SupplierResponse(
                Id: supplier.Id,
                Name: supplier.Organization.Name,
                Country: supplier.Organization.Country!,
                City: supplier.Organization.City!,
                StreetAddress: supplier.Organization.StreetAddress!,
                Email: supplier.Organization.Email!,
                TaxNo: supplier.Organization.TaxNo,
                Phone: supplier.Organization.Phone,
                FileId: supplier.Organization.FileId!,
                ImageUrl: null,
                Fax: supplier.Organization.FaxNo,
                ApprovedDate: null,
                IsDocumentsApproved: false,
                IsApproved: false,
                Categories: supplier.SupplierCategories?
                    .Select(c => new SupplierCategoryResponse(supplier.Id, c.CategoryId)).ToList(),
                Department: null,
                Title: null
            );
        }
        private static string GetImageUrl(string imageName)
        {
            return string.IsNullOrEmpty(imageName) ? "" : $"{AppConstants.BaseUrl}{AppConstants.ImgUploadPath}/{imageName}";
        }

        private string GenerateRandomPassword()
        {
            var randomNumber = new byte[8];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            int numericCode = BitConverter.ToInt32(randomNumber, 0);
            numericCode = Math.Abs(numericCode);
            numericCode %= 1000000;

            // Generate random uppercase letter (ASCII range: 65-90)
            char randomUpperCase = (char)(new Random().Next(65, 91));

            // Generate random lowercase letter (ASCII range: 97-122)
            char randomLowerCase = (char)(new Random().Next(97, 123));

            // Generate random non-alphanumeric character
            string nonAlphanumericChars = @"!@#$_";

            Random rnd = new Random();
            char randomNonAlphanumeric = nonAlphanumericChars[rnd.Next(nonAlphanumericChars.Length)];

            // Combine all components into a string
            return $"{randomUpperCase}{numericCode:D6}{randomUpperCase}{randomLowerCase}";
        }

        /// <summary>
        /// Deletes a supplier.
        /// </summary>
        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();
            var supplier = await _unitOfWork.GenericRepository<Supplier>().GetByIdAsync(id);
            _unitOfWork.GenericRepository<Supplier>().SoftDelete(supplier);
            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Deleted<string>()
                              : BadRequest<string>("Something went wrong");
        }


    }
}
