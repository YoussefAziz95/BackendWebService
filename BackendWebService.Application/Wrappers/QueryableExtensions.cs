using Application.DTOs.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Wrappers;

public static class QueryableExtensions
{
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
