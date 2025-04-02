using System.Net;

namespace Application.Contracts.DTOs
{
    /// <summary>
    /// Represents a generic response model interface used to communicate the outcome of an operation along with optional data.
    /// </summary>
    /// <typeparam name="T">The type of the data contained in the response.</typeparam>
    public interface IResponse<T>
    {
        /// <summary>
        /// Gets or sets the HTTP status code associated with the response.
        /// </summary>
        HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the operation succeeded.
        /// </summary>
        bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets a message describing the outcome of the operation.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets a list of errors that occurred during the operation, if any.
        /// </summary>
        List<string>? Errors { get; set; }

        /// <summary>
        /// Gets or sets the data returned by the operation.
        /// </summary>
        T? Data { get; set; }
    }
}
