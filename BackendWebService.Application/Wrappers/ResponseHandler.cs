using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Domain.Enums;
using System.Collections.Generic;

namespace Application.Wrappers
{
    /// <summary>
    /// Class for handling responses and generating response objects.
    /// </summary>
    public class ResponseHandler
    {
        /// <summary>
        /// Generates a response indicating successful deletion.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <returns>A response object indicating successful deletion.</returns>
        public IResponse<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }

        /// <summary>
        /// Generates a response indicating successful email verification.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <returns>A response object indicating successful email verification.</returns>
        public IResponse<T> EmailVerified<T>()
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true,
                Message = "EmailDto Verified Successfully"
            };
        }

        /// <summary>
        /// Generates a response indicating successful email sending.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <returns>A response object indicating successful email sending.</returns>
        public IResponse<T> EmailSent<T>()
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true,
                Message = "EmailDto Sent Successfully"
            };
        }

        /// <summary>
        /// Generates a response indicating successful password update.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <returns>A response object indicating successful password update.</returns>
        public IResponse<T> PasswordUpdated<T>()
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true,
                Message = "Password Updated Successfully"
            };
        }

        /// <summary>
        /// Generates a response indicating success with provided data.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="entity">The data to include in the response.</param>
        /// <returns>A response object indicating success with provided data.</returns>
        public IResponse<T> Success<T>(T entity)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true
            };
        }

        /// <summary>
        /// Generates a response indicating success with a message.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="message">The success message.</param>
        /// <returns>A response object indicating success with a message.</returns>
        public IResponse<T> Success<T>(string message = null!)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true
            };
        }

        /// <summary>
        /// Generates a response indicating success with an ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>A response object indicating success with an ID.</returns>
        public IResponse<int> Success(int id)
        {
            return new Response<int>()
            {
                Data = id,
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true
            };
        }

        /// <summary>
        /// Generates a response indicating successful upload.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="entity">The uploaded entity.</param>
        /// <returns>A response object indicating successful upload.</returns>
        public IResponse<T> Uploaded<T>(T entity)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true,
                Message = "Uploaded Successfully"
            };
        }

        /// <summary>
        /// Generates a response indicating successful update.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="entity">The updated entity.</param>
        /// <param name="message">The success message.</param>
        /// <returns>A response object indicating successful update.</returns>
        public IResponse<T> Updated<T>(T entity, string message = null!)
        {
            return new Response<T>()
            {
                Data = entity,
                Message = message == null! ? "Updated Successfully" : message,
                StatusCode = ApiResultStatusCode.Ok,
                Succeeded = true
            };
        }

        /// <summary>
        /// Generates a response indicating unauthorized access.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <returns>A response object indicating unauthorized access.</returns>
        public IResponse<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.UnAuthorized,
                Succeeded = true,
                Message = "UnAuthorized",
            };
        }

        /// <summary>
        /// Generates a response indicating a bad request with a message.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="message">The error message.</param>
        ///        /// <returns>A response object indicating a bad request with a message.</returns>
        public IResponse<T> BadRequest<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null! ? "Bad Request" : message
            };
        }

        /// <summary>
        /// Generates a response indicating a bad request with errors.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="errors">The list of errors.</param>
        /// <returns>A response object indicating a bad request with errors.</returns>
        public IResponse<T> BadRequest<T>(List<string> errors)
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Succeeded = false,
                Errors = errors
            };
        }

        /// <summary>
        /// Generates a response indicating not found with a message.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A response object indicating not found with a message.</returns>
        public IResponse<T> NotFound<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Succeeded = false,
                Message = message == null! ? "Not Found" : message
            };
        }

        /// <summary>
        /// Generates a response indicating success with provided data and a message.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="entity">The data to include in the response.</param>
        /// <param name="meta">Additional metadata.</param>
        /// <returns>A response object indicating success with provided data and a message.</returns>
        public IResponse<T> Created<T>(T entity, object meta = null!)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = ApiResultStatusCode.Created,
                Succeeded = true
            };
        }

        /// <summary>
        /// Generates a response indicating success with an ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>A response object indicating success with an ID.</returns>
        public IResponse<int> Created(int id)
        {
            return new Response<int>()
            {
                Data = id,
                StatusCode = ApiResultStatusCode.Created,
                Succeeded = true
            };
        }

        /// <summary>
        /// Generates a response indicating a failed dependency to delete.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A response object indicating a failed dependency to delete.</returns>
        public IResponse<T> CannotDelete<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = ApiResultStatusCode.FailedDependency,
                Succeeded = false,
                Message = message == null! ? "Connot Delete Failed Dependency" : message
            };
        }
    }
}

