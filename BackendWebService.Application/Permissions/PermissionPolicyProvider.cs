using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Application.Permissions
{
    /// <summary>
    /// Custom authorization policy provider for handling permission-based policies.
    /// </summary>
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        /// <summary>
        /// Gets the fallback policy provider.
        /// </summary>
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionPolicyProvider"/> class.
        /// </summary>
        /// <param name="options">The authorization options.</param>
        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        /// <inheritdoc/>
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        /// <inheritdoc/>
        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync()!;
        }

        /// <inheritdoc/>
        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.Split('.').Length == 4)
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new PermissionRequirement(policyName));
                return Task.FromResult(policy.Build())!;
            }

            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
