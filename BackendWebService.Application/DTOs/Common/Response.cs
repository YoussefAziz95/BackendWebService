using Application.Contracts.DTOs;
using System.Net;

namespace Application.DTOs.Common
{
    /// <summary>
    /// Represents a generic response model used to communicate the outcome of an operation along with optional data.
    /// </summary>
    /// <typeparam name="T">The type of the data contained in the response.</typeparam>
    public class Response<T> : IResponse<T> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        public Response()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class with the provided data and optional message.
        /// </summary>
        /// <param name="data">The data returned by the operation.</param>
        /// <param name="message">An optional message describing the outcome of the operation.</param>
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class with the provided message and sets the <see cref="Succeeded"/> property to <c>false</c>.
        /// </summary>
        /// <param name="message">The message describing the failure of the operation.</param>
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class with the provided message and success status.
        /// </summary>
        /// <param name="message">The message describing the outcome of the operation.</param>
        /// <param name="succeeded">The success status of the operation.</param>
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the HTTP status code associated with the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the operation succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets a message describing the outcome of the operation.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a list of errors that occurred during the operation, if any.
        /// </summary>
        public List<string>? Errors { get; set; }

        /// <summary>
        /// Gets or sets the data returned by the operation.
        /// </summary>
        public T? Data { get; set; }
    }
}

