using Application.Contracts.DTOs;
using Application.Contracts.Presistence;
using Application.Contracts.Presistence.Identities;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.User;
using Application.MappingProfiles;
using Application.Wrappers;
using AutoMapper;
using Domain.Constants;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Application.Implementations
{
    /// <summary>
    /// Service for managing application users.
    /// </summary>
    public sealed class UserService : ResponseHandler, IUserService
    {
        private readonly IClientRepository _clientRepositpry;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(IClientRepository clientRepositpry,
            IUnitOfWork unitOfWork,
            UserManager<User> userManager, 
            IMapper mapper)
        {
            _clientRepositpry = clientRepositpry;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> AddAsync(AddUserRequest request)
        {
            if (!await UniqueEmail(request.Email))
                return BadRequest<int>("EmailDto Address is already Registered.");

            if (!await UniqueUsername(request.Username))
                return BadRequest<int>("Username is already used.");

            var companyId = IClientRepository._userInfo.CompanyId;
            if (companyId == -1)
                return BadRequest<int>("Please Specify Company! You Are not Supposed to be here!");
            else if (companyId == 0 && (request.CompanyId is null | request.CompanyId == 0))
                return BadRequest<int>("SuperAdmin! Please Specify Company.");
            else if (companyId > 0)
                request.CompanyId = companyId;
            if (request.MainRole is null | Enum.Parse<RoleEnum>(request.MainRole) == 0)
                return BadRequest<int>("Please Specify Customer Type");

            var user = _mapper.Map<User>(request);
            user.OrganizationId = (int)request.CompanyId;
            user.Title = request.Title is null ? " " : request.Title;
            user.Department = request.Department is null ? string.Empty : request.Department;
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            await _userManager.AddToRolesAsync(user, request.Roles.Select(r => r));
            await _unitOfWork.SaveAsync();

            return Created(user.Id);
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
            return $"{numericCode:D6}{randomUpperCase}{randomLowerCase}{randomNonAlphanumeric}";
        }

        /// <inheritdoc/>
        public async Task<IResponse<UserResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<UserResponse>();

            var response = GetById(id);

            return Success(response);
        }

        /// <inheritdoc/>
        public async Task<IResponse<bool>> ChangePassword(int userId, ChangePasswordRequest request)
        {
            if (!CheckIdExists(userId))
                return NotFound<bool>();

            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ChangePasswordAsync(user!, request.OldPassword, request.NewPassword);
            return result.Succeeded ? PasswordUpdated<bool>()
                                    : BadRequest<bool>();
        }

        /// <inheritdoc/>
        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<User>().Get(u => u.Id == id) is not null;
        }

        /// <inheritdoc/>
        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var user = await _userManager.FindByIdAsync(id.ToString());
            _unitOfWork.GenericRepository<User>().SoftDelete(user!);
            await _userManager.UpdateAsync(user!);
            return Deleted<string>();
        }

        /// <inheritdoc/>
        public IResponse<UserResponse> Get(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<UserResponse>();

            var response = GetById(id);

            return Success(response);
        }

        /// <inheritdoc/>
        public PaginatedResponse<UserResponse> GetUsersPaginated(GetPaginatedRequest request)
        {
            string sortExpression = string.IsNullOrEmpty(request.sortBy) ?
                                        $"Id {(request.sortDescending ? AppConstants.descending : AppConstants.ascending)}" :
            $"{request.sortBy} {(request.sortDescending ? AppConstants.descending : AppConstants.ascending)}";
            var companyId = IClientRepository._userInfo.CompanyId;

            var users = _unitOfWork.GenericRepository<User>()
                        .GetAll()
                        .AsQueryable();
            var userResponses = UserMapper.GetResponses(users.ToList(), _userManager, _unitOfWork).AsQueryable();
            if (companyId > 0)
            {
                userResponses = userResponses.Where(c => c.CompanyId == companyId);
            }
            var papaginatedList = userResponses.ToPaginatedList((int)request.pageNumber!, (int)request.pageSize!);

            return papaginatedList;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> UpdateAsync(int id, UpdateUserRequest request)
        {
            if (!CheckIdExists(id))
                return NotFound<int>();

            if (!CheckEmailUpdate(request.Email!, id))
                return BadRequest<int>("This email is already assigned to another user");

            var user = await _userManager.FindByIdAsync(id.ToString());
            user!.Email = string.IsNullOrEmpty(request.Email) ? user!.Email : request.Email;
            user.FirstName = string.IsNullOrEmpty(request.FirstName) ? user.FirstName : request.FirstName;
            user.LastName = string.IsNullOrEmpty(request.LastName) ? user.LastName : request.LastName;
            user.MainRole = Enum.Parse<RoleEnum>(request.MainRole);
            user.OrganizationId = request.CompanyId is not null ? (int)request.CompanyId : user.OrganizationId;
            user.Title = request.Title is not null ? request.Title : user.Title;
            user.Department = request.Department is not null ? request.Department : user.Department;
            var roles = await _userManager.GetRolesAsync(user);

            await _userManager.UpdateAsync(user);
            foreach (var role in request.Roles)
            {
                if (!roles.Contains(role))
                    await _userManager.AddToRoleAsync(user, role);
                else
                {
                    if (roles is not null)
                        roles = roles.Where(r => r != role).ToList();
                }

            }
            foreach (var role in roles)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }
            return Success(user.Id);
        }

        private UserResponse GetById(int id)
        {
            return UserMapper.GetResponse(GetUserById(id), _userManager, _unitOfWork);
        }

        private User GetUserById(int id)
        {
            return _unitOfWork.GenericRepository<User>()
                             .Get(u => u.Id == id);
        }

        private async Task<bool> UniqueEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email) is null;
        }

        private bool CheckEmailUpdate(string email, int userId)
        {
            var userWithSameEmail = _unitOfWork.GenericRepository<User>().Get(u => u.Email == email);

            if (userWithSameEmail is not null && userWithSameEmail.Id != userId)
                return false;

            return true;
        }

        private async Task<bool> UniqueUsername(string username)
        {
            return await _userManager.FindByNameAsync(username) is null;
        }
        public async Task<IResponse<bool>> ActivateDeactivateOtp(ActivateDeactivateOtpRequest request)
        {
            if (!CheckIdExists(request.Id))
                return NotFound<bool>();
            else
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());
                user.HasOtp = request.HasOtp;
                await _userManager.UpdateAsync(user);

            }
            return Success(true);
        }
    }
}
