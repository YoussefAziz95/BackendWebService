using Application.Contracts.DTOs;
using Application.Contracts.Infrastructures;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Companies;
using Application.DTOs.Companies;
using Application.DTOs.Suppliers;
using Application.DTOs.Users;
using Application.Model.EmailDto;
using Application.Wrappers;
using AutoMapper;
using Domain;



namespace Application.Implementations
{
    /// <summary>
    /// Services for handling company-related operations.
    /// </summary>
    public class CompanyService : ResponseHandler, ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ICompanyRepository _companyRepository;

        /// <summary>
        /// Constructor for CompanyService.
        /// </summary>
        public CompanyService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IEmailService emailService,
                              ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _companyRepository = companyRepository;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> AddAsync(AddCompanyRequest request)
        {
            if (_unitOfWork.GenericRepository<Organization>().Exists(c => c.Email == request.Email)
              || _unitOfWork.GenericRepository<User>().Exists(c => c.Email == request.Email))
                return BadRequest<int>("EmailDto Already Exist!");

            var company = _mapper.Map<Company>(request);
            company.Organization = _mapper.Map<Organization>(request);
            company.Id = _companyRepository.Add(company);

            var user = _mapper.Map<AddUserCompanyRequest>(company);
            user = _mapper.Map<AddUserCompanyRequest>(request);

            //var UserResponse = await _applicationUserService.AddUserCompanyAsync(user);
            //if (!UserResponse.Succeeded)
            //    return BadRequest<int>("Error Creating Customer");
            try
            {
                var subject = "Suppliers " + company.Organization.Name + " Created";
                var body = " with email = " + user.Email + " and with password = " + user.Password;
                var emailDto = new EmailDto(subject, body, company.Organization.Email, "", "", DateTime.Now, 1);
                var emailSent = await _emailService.Send(emailDto);
                await _unitOfWork.SaveAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Created(company.Id);
        }


        /// <inheritdoc/>
        public bool CheckIdExists(int id)
        {
            return _companyRepository.CheckIdExists(id);
        }

        /// <inheritdoc/>
        public async Task<PaginatedResponse<GetPaginatedCompany>> GetPaginated(GetPaginatedRequest request)
        {


            var paginatedList = _companyRepository.GetPaginated()
                                .ToPaginatedList((int)request.pageNumber!, (int)request.pageSize!);
            return paginatedList;
        }

        /// <inheritdoc/>
        public async Task<IResponse<CompanyResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<CompanyResponse>();

            var response = _companyRepository.GetResponse(id);

            return Success(response);
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> UpdateAsync(UpdateCompanyRequest request)
        {
            try
            {
                if (!CheckIdExists(request.Id))
                    return NotFound<int>();
                var oldsupplier = _mapper.Map<Company>(request);

                try
                {
                    oldsupplier.Id = _companyRepository.Update(oldsupplier);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                var user = _unitOfWork.GenericRepository<User>().Get(b => b.Email == oldsupplier.Organization.Email);


                user.Department = request.Department is not null ? request.Department : user.Department;
                user.Title = request.Title is not null ? request.Title : user.Title;
                _unitOfWork.GenericRepository<User>().Update(user);
                _unitOfWork.Save();
                return oldsupplier.Id > 0 ? Success(oldsupplier.Id)
                                  : BadRequest<int>("Something went wrong");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return BadRequest<int>();
        }

        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var company = await _unitOfWork.GenericRepository<Company>().GetByIdAsync(id);
            _unitOfWork.GenericRepository<Company>().SoftDelete(company);
            var result = await _unitOfWork.SaveAsync();

            return result > 0 ? Deleted<string>()
                              : BadRequest<string>("Something went wrong");
        }
    }
}
