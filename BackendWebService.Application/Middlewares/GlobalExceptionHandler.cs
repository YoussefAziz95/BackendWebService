using Application.Features.Common;
using Application.Exceptions;
using Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Middleware
{
    /// <summary>
    /// Middleware for handling global exceptions in the application.
    /// </summary>
    public class GlobalExceptionHandler : IMiddleware
    {
        /// <summary>
        /// Handles exceptions in the application pipeline.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = ex.Message };
                switch (ex)
                {
                    case UnauthorizedAccessException e:
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = ApiResultStatusCode.UnAuthorized;
                        response.StatusCode = (int)ApiResultStatusCode.UnAuthorized;
                        break;

                    case ValidationException e:
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = ApiResultStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)ApiResultStatusCode.UnprocessableEntity;
                        break;

                    case CustomValidationException e:
                        responseModel.Message = e.Message;
                        responseModel.Errors = e.Errors;
                        responseModel.StatusCode = ApiResultStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)ApiResultStatusCode.UnprocessableEntity;
                        break;

                    case KeyNotFoundException e:
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = ApiResultStatusCode.NotFound;
                        response.StatusCode = (int)ApiResultStatusCode.NotFound;
                        break;

                    case DbUpdateException e:
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = ApiResultStatusCode.BadRequest;
                        response.StatusCode = (int)ApiResultStatusCode.BadRequest;
                        break;

                    case Exception e:
                        if (e.GetType().ToString() == "ApiException")
                        {
                            responseModel.Message += e.Message;
                            responseModel.Message += e.InnerException == null! ? "" : "\n" + e.InnerException.Message;
                            responseModel.StatusCode = ApiResultStatusCode.BadRequest;
                            response.StatusCode = (int)ApiResultStatusCode.BadRequest;
                        }
                        responseModel.Message = e.Message;
                        responseModel.Message += e.InnerException == null! ? "" : "\n" + e.InnerException.Message;

                        responseModel.StatusCode = ApiResultStatusCode.InternalServerError;
                        response.StatusCode = (int)ApiResultStatusCode.InternalServerError;
                        break;

                    default:
                        responseModel.Message = ex.Message;
                        responseModel.StatusCode = ApiResultStatusCode.InternalServerError;
                        response.StatusCode = (int)ApiResultStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }


    }
}
