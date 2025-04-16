using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Manager
{
    public interface IAppRoleManager
    {
        public Task<IdentityResult> AddClaimAsync(Role role, Claim claim);
        public Task<IdentityResult> CreateAsync(Role role);
        public Task<IdentityResult> DeleteAsync(Role role);
        public Task<Role?> FindByIdAsync(string roleId);
        public Task<Role?> FindByNameAsync(string roleName);
        public Task<IList<Claim>> GetClaimsAsync(Role role);
        public Task<string> GetRoleIdAsync(Role role);
        public Task<string?> GetRoleNameAsync(Role role);
        public string? NormalizeKey(string? key);
        public Task<IdentityResult> RemoveClaimAsync(Role role, Claim claim);
        public Task<bool> RoleExistsAsync(string roleName);
        public Task<IdentityResult> SetRoleNameAsync(Role role, string? name);
        public Task<IdentityResult> UpdateAsync(Role role);
        public Task UpdateNormalizedRoleNameAsync(Role role);
    }
}
