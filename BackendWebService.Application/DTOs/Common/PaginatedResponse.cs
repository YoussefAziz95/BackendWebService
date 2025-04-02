using Application.Contracts.DTOs;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.DTOs.Common
{
    /// <summary>
    /// Represents a paginated response containing data of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the paginated response.</typeparam>
    public class PaginatedResponse<T> : IResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class with default values.
        /// </summary>
        /// <param name="data">The list of data.</param>
        /// <param name="currentPage">The current page number.</param>
        /// <param name="totalCount">The total count of items.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="succeeded">A value indicating whether the operation succeeded.</param>
        public PaginatedResponse(List<T> data = default!, int currentPage = 1, int totalCount = 0, int pageSize = 10, bool succeeded = true)
        {
            Data = data;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
            PageSize = pageSize;
            Succeeded = succeeded;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PaginatedResponse{T}"/> class representing a successful response.
        /// </summary>
        /// <param name="data">The list of data.</param>
        /// <param name="count">The total count of items.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <returns>A new instance of <see cref="PaginatedResponse{T}"/> representing a successful response.</returns>
        public static PaginatedResponse<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new(data, page, count, pageSize, true);
        }

        /// <summary>
        /// Gets or sets the list of data.
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total count of items.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the size of each page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the operation succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of errors associated with the response.
        /// </summary>
        public List<string>? Errors { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        public HttpStatusCode StatusCode { get; set; }
        T? IResponse<T>.Data { get; set; }
    }
}
