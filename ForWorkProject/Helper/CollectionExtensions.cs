using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ForWorkProject.Helper;

public static class CollectionExtensions
{
    public static async Task<IEnumerable<T>> ToPageListAsync<T>(this IQueryable<T> source, PaginationParams? paginationParams)
    {
        paginationParams = paginationParams ?? new PaginationParams();
        HttpContextHelper.AddResponseHeader("X-Pagenation",JsonSerializer.Serialize(new PaginationMetaData(source.Count(),paginationParams.Size,paginationParams.Page)));
        return await source.Skip(paginationParams.Size * (paginationParams.Page-1)).Take(paginationParams.Size).ToListAsync();
    }
}
