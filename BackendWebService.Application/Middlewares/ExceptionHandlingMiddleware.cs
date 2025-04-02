using Application.Contracts.Services;
using Application.DTOs.ExceptionLog;
using Application.DTOs.Logging;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace Application.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {

        private readonly ILoggingService _loggingService;
        private readonly IExceptionLogService _exceptionLogService;

        public ExceptionHandlingMiddleware(ILoggingService loggingService, IExceptionLogService exceptionLogService)
        {

            _loggingService = loggingService;
            _exceptionLogService = exceptionLogService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            var stackTrace = new StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);
            var method = frame.GetMethod();

            var sourceLayer = method.DeclaringType?.Namespace;
            var sourceClass = method.DeclaringType?.Name;
            var sourceLineNumber = frame.GetFileLineNumber();
            var exceptionCode = Enum.TryParse(typeof(ExceptionEnum), ex.GetType().Name, out var parsedEnum)
                ? (ExceptionEnum)parsedEnum
                : ExceptionEnum.UnknownException;


            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var log = new LoggingDto
            {
                UserId = null,
                Message = ex.Message,
                Suggestion = ex.InnerException?.Message ?? null,
                LogType = exceptionCode.ToString(),
                Timestamp = DateTime.UtcNow,
                SourceLayer = sourceLayer ?? "UnknownNamespace",
                SourceClass = sourceClass ?? "UnknownClass",
                SourceLineNumber = sourceLineNumber > 0 ? sourceLineNumber : 0
            };

            _loggingService.Log(log);
            var exception = new ExceptionDto()
            {
                KeyExceptionMessage = ex.GetType().Name,

                ExceptionCode = (int)exceptionCode
            };
            _exceptionLogService.Add(exception);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(ex.Message);
        }




    }

}
