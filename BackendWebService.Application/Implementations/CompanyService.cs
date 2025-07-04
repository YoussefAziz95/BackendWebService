﻿using Application.Contracts.Features;
using Application.Contracts.Infrastructures;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Model.EmailDto;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

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

            var user = _mapper.Map<CreateUserCompanyRequest>(company);
            user = _mapper.Map<CreateUserCompanyRequest>(request);

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
        public async Task<PaginatedResponse<CompanyAllResponse>> GetPaginated(GetPaginatedCompanyRequest request)
        {

            var query = _unitOfWork.GenericRepository<Company>().GetAll(
                include: c => c.Include(o => o.Organization))
            .Select(c => new CompanyAllResponse(
                c.Id,
                c.CompanyName,
                c.Organization.Addresses.FirstOrDefault().FullAddress,
                c.Organization.Addresses.FirstOrDefault().Zone,
                Enum.GetName(typeof(OrganizationEnum), c.Organization.Type))).AsQueryable();
            var result = query.ToPaginatedList((int)request.PageNumber!, (int)request.PageSize!);
            return result;
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
