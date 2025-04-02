using Application.Contracts.Presistence;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Permission;
using Dapper;
using Domain.Constants;

using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Reflection;
using System.Security.Claims;
using Application.Contracts.Presistence.Identities;
using Application.Contracts.DTOs;
using System.Linq;

namespace Application.Implementations
{
    /// <summary>
    /// Service for managing permissions.
    /// </summary>
    public sealed class PermissionService : ResponseHandler, IPermissionService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly ISP_Call _sp_call;
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// Constructs a new PermissionService.
        /// </summary>
        /// <param name="roleManager">The role manager for managing roles.</param>
        /// <param name="sp_call">The stored procedure call handler.</param>
        public PermissionService(RoleManager<Role> roleManager,
                                 ISP_Call sp_call,
                                 IRoleRepository roleRepository)
        {
            _roleManager = roleManager;
            _sp_call = sp_call;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Adds permissions to a role.
        /// </summary>
        /// <param name="request">The request containing role ID and permissions to be added.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        public async Task<IResponse<int>> AddPermissionsToRole(AddPermissionsToRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role == null)
                return NotFound<int>();
            var roleClaims = await _roleManager.GetClaimsAsync(role!);
            foreach (var claim in roleClaims)
                await _roleManager.RemoveClaimAsync(role!, claim);
            if (!request.Claims.Any(c => c == "Users.Button.Permission.View"))
                request.Claims.Add("Users.Button.Permission.View");
            foreach (var claim in request.Claims)
                await _roleManager.AddClaimAsync(role!, new Claim(AppConstants.Permission, claim));
            
            return Created(1);
        }

        /// <summary>
        /// Retrieves all permissions.
        /// </summary>
        /// <returns>A response containing a list of all permissions.</returns>
        public IResponse<List<string>> GetAll()
        {
            return Success(GetAllPermissions());
        }

        /// <summary>
        /// Retrieves permissions assigned to a role.
        /// </summary>
        /// <param name="roleId">The ID of the role.</param>
        /// <returns>A response containing the permissions assigned to the role.</returns>
        public async Task<IResponse<PermissionResponse>> GetRolePermissions(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
                return NotFound<PermissionResponse>();

            var roleClaims = _roleRepository.GetRolePermissions(roleId);
            var response = new PermissionResponse()
            {
                RoleId = roleId,
                Claims = roleClaims,
                Name = role!.Name!
            };
            return Success(response);
        }

        /// <summary>
        /// Retrieves the pages accessible to a user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>A response containing the pages accessible to the user.</returns>
        public async Task<IResponse<IEnumerable<UserPagesResponse>>> GetUserPages(int id)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@UserId ", id, DbType.Int32);
            var responses = _sp_call.List<UserPagesResponse>("sp_GetUserPages", dbParams);
            return Success(responses.AsEnumerable());
        }

        private List<string> GetAllPermissions()
        {
            Type permissionsType = typeof(PermissionConstants);
            FieldInfo[] fields = permissionsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            List<string> permissionsList = new List<string>();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    string value = (string)field.GetValue(null)!;
                    permissionsList.Add(value);
                }
            }
            return permissionsList;
        }
    }
}
