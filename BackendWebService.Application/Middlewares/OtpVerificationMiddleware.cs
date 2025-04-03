using Domain.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Middleware
{
    /// <summary>
    /// Middleware for verifying OTP (One-Time Password) authentication.
    /// </summary>
    public class OtpVerificationMiddleware : IMiddleware
    {
        /// <summary>
        /// Invokes the OTP verification middleware.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.User.Identity.IsAuthenticated && !IsOtpVerified(context))
            {
                if (context.Request.Path == "/api/auth/ConfirmOtp")
                {
                    await next(context);
                    return;
                }
                context.Response.StatusCode = 401;
                return;
            }
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if the OTP (One-Time Password) is verified.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>True if the OTP is verified; otherwise, false.</returns>
        private bool IsOtpVerified(HttpContext context)
        {
            if (!context.Session.Keys.Contains(AppConstants.UserOtpType))
                return true;
            return context.Session.GetString(AppConstants.UserOtpType) == "true";
        }
    }

    /// <summary>
    /// Extension method used to add the OTP verification middleware to the HTTP request pipeline.
    /// </summary>
    public static class OtpVerificationMiddlewareExtensions
    {
        /// <summary>
        /// Adds the OTP verification middleware to the HTTP request pipeline.
        /// </summary>
        /// <param name="builder">The application builder.</param>
        /// <returns>The application builder with the OTP verification middleware added.</returns>
        public static IApplicationBuilder UseOtpVerificationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OtpVerificationMiddleware>();
        }
    }
}
