using Application.Contracts.DTOs;
using Application.Contracts.Persistences;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Permission;
using Application.DTOs.Roles;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Implementations
{
    /// <summary>
    /// Services implementation for managing application roles.
    /// </summary>
    public sealed class ApplicationRoleService : ResponseHandler, IApplicationRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionService _permissionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleService"/> class.
        /// </summary>
        public ApplicationRoleService(IUnitOfWork unitOfWork, UserManager<User> userManager,
                                       RoleManager<Role> roleManager,
                                       IMapper mapper, IPermissionService permissionService,
                                       IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _permissionService = permissionService;
            _roleRepository = roleRepository;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> AddRoleAsync(CreateRoleRequest request)
        {
            var role = _mapper.Map<Role>(request);

            var result = await _roleManager.CreateAsync(role);
            var addPermissionsToRoleRequest = new AddPermissionsToRoleRequest()
            {
                Claims = request.Claims,
                RoleId = role.Id,
            };
            await _permissionService.AddPermissionsToRole(addPermissionsToRoleRequest);
            return result.Succeeded ? Created(role.Id) :
                    BadRequest<int>("Something went wrong");
        }

        /// <inheritdoc/>
        public async Task<IResponse<string>> AddRoleToUserAsync(AddRoleToUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (await _userManager.IsInRoleAsync(user!, request.Role))
                return BadRequest<string>("Customer already assigned to this role");

            var result = await _userManager.AddToRoleAsync(user!, request.Role);

            return result.Succeeded ? Success(string.Empty) : BadRequest<string>("Something went wrong");
        }

        /// <inheritdoc/>
        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<Role>().Get(u => u.Id == id) is not null;
        }

        /// <inheritdoc/>
        public async Task<IResponse<string>> DeleteRoleAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var role = await _roleManager.FindByIdAsync(id.ToString());
            _unitOfWork.GenericRepository<Role>().SoftDelete(role!);
            await _unitOfWork.SaveAsync();
            return Success(string.Empty);
        }

        /// <inheritdoc/>
        public async Task<IResponse<RoleResponse>> GetRoleAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<RoleResponse>();

            var role = _roleRepository.getRole(id);
            return role is not null ? Success(role) :
                    BadRequest<RoleResponse>("Something went wrong");
        }

        /// <inheritdoc/>
        public async Task<PaginatedResponse<RolesResponse>> GetRolesPaginated(GetPaginatedRequest request)
        {
            var roles = _roleRepository.getRoles();
            var paginatedList = _mapper.ProjectTo<RolesResponse>(roles)
                                .ToPaginatedList((int)request.pageNumber!, (int)request.pageSize!);

            return paginatedList;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> UpdateRoleAsync(int id, UpdateRoleRequest request)
        {
            if (!CheckIdExists(id))
                return NotFound<int>();

            var roleWithSameName = await _roleManager.FindByNameAsync(request.Role);
            if (roleWithSameName is not null && roleWithSameName!.Id != id)
                return BadRequest<int>("This Roles is already exists");

            var role = await _roleManager.FindByIdAsync(id.ToString());
            role!.Name = request.Role;
            role.NormalizedName = request.Role.ToUpper();
            var addPermissionsToRoleRequest = new AddPermissionsToRoleRequest()
            {
                Claims = request.Claims,
                RoleId = id
            };
            await _permissionService.AddPermissionsToRole(addPermissionsToRoleRequest);
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded ? Success(role.Id) :
                BadRequest<int>("Something went wrong");
        }
    }
}
