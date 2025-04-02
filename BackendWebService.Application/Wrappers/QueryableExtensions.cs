using Application.DTOs.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Wrappers
{
    /// <summary>
    /// Extension methods for IQueryable to support pagination.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Converts an IQueryable to a paginated list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the query.</typeparam>
        /// <param name="source">The queryable source.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <returns>A paginated response containing the items, total count, page number, and page size.</returns>
        public static PaginatedResponse<T> ToPaginatedList<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = source.AsNoTracking().Count();
            if (count == 0) return PaginatedResponse<T>.Success(new List<T>(), count, pageNumber, pageSize);
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PaginatedResponse<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}
