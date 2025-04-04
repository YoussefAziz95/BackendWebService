using Application.Contracts.DTOs;
using Application.Contracts.Persistences;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.Permission;
using Application.Wrappers;
using BackendWebService.Domain.Entities.User;
using Domain;
using Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Implementations
{
    /// <summary>
    /// Services for managing permissions.
    /// </summary>
    public sealed class PermissionService : ResponseHandler, IPermissionService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructs a new PermissionService.
        /// </summary>
        /// <param name="roleManager">The role manager for managing roles.</param>
        /// <param name="sp_call">The stored procedure call handler.</param>
        public PermissionService(RoleManager<Role> roleManager,
                                 IUnitOfWork unitOfWork,
                                 IRoleRepository roleRepository)
        {
            _roleManager = roleManager;
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
            var claims = _unitOfWork.GenericRepository<UserRole>()
                .GetAll(ur => ur.UserId == id, include: r => r.Include(r => r.Role).ThenInclude(rc => rc.RoleClaim))
                .Select(rc => new { id = rc.RoleId, claims = rc.Role.RoleClaim })
                .ToList()
                .Select(rc => new UserPagesResponse
                {
                    id = rc.id,
                    Groups = rc.claims.Select(c => c.ClaimType?.Split('.')[0]).First(),
                    menu = rc.claims.Select(c => c.ClaimType?.Split('.')[1]).First(),
                    page = rc.claims.Select(c => c.ClaimType?.Split('.')[2]).First(),
                    permission =  rc.claims.Select(c => c.ClaimType?.Split('.')[3]).First()
                });


            return Success(claims);
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
