using Domain.Shared.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Applies search, sorting, and pagination to an IQueryable source asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The source IQueryable to apply the operations on.</param>
        /// <param name="parameters">QueryParameters object containing pagination, search, and sorting information.</param>
        /// <param name="searchFunc">
        /// Optional function to apply search filtering. 
        /// Takes the IQueryable and a search term, returns a filtered IQueryable.
        /// If null, no search filtering is applied.
        /// </param>
        /// <param name="sortFunc">
        /// Optional function to apply sorting. 
        /// Takes the IQueryable, a field name to sort by, and a boolean indicating descending order, returns a sorted IQueryable.
        /// If null, no sorting is applied.
        /// </param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a PagedResult with the filtered, sorted, and paginated items and total count.</returns>
        public static async Task<PagedResult<T>> ApexQueryAsync<T>(
            this IQueryable<T> query,
            QueryParameters parameters,
            Func<IQueryable<T>, string?, IQueryable<T>>? searchFunc = null)
        {
            if (searchFunc != null)
                query = searchFunc(query, parameters.SearchTerm);

            if (! parameters.OrderBy.IsNullOrEmpty() )
                query = Sortfunc(query, parameters.OrderBy!, parameters.IsDescending);

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalItems = totalItems,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize
            };
        }

        private static IQueryable<T> Sortfunc<T>(IQueryable<T> query, string orderBy, bool isDesc)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query;

            orderBy = char.ToUpper(orderBy[0]) + orderBy.Substring(1);
            return isDesc
                ? query.OrderByDescending(e => EF.Property<object>(e!, orderBy))
                : query.OrderBy(e => EF.Property<object>(e!, orderBy));
        }


    }

}
