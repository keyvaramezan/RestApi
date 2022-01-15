using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace RestApi.Infrastructure.Data.Service.Paging
{
    public static class DbServiceExtentions
    {
        public static async Task<PagedList<T>> Paging<T>(this IQueryable<T> query,
                                                        PagingParam? paging = default(PagingParam))
        {
            if (paging == null)
            {
                paging = new PagingParam();
            }
            var totalCount = await query.CountAsync();
            var result = await query.Skip((paging.PageIndex - 1) * paging.PageSize)
                                    .Take(paging.PageSize).ToListAsync();
            return new PagedList<T>(result, totalCount);
        }
        public static IQueryable<T> Sorting<T>(this IQueryable<T> query,
                                               string? sorting = default(string))
        {
            if (string.IsNullOrEmpty(sorting))
            {
                return query;
            }
            return query.OrderBy(sorting);
        }
    }
}
