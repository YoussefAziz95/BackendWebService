using Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Application.Permissions
{
    /// <summary>
    /// Authorization handler for permissions.
    /// </summary>
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionAuthorizationHandler"/> class.
        /// </summary>
        public PermissionAuthorizationHandler()
        {

        }

        /// <summary>
        /// Handles the requirement asynchronously.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="requirement">The permission requirement.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User is null)
                return Task.CompletedTask;

            var canAccess = context.User.Claims.Any(c => c.Type == AppConstants.Permission && c.Value == requirement.Permission);

            if (canAccess)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
