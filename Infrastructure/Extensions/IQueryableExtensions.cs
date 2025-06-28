using Domain.Shared.Pagination;
using Microsoft.EntityFrameworkCore;


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
            Func<IQueryable<T>, string?, IQueryable<T>>? searchFunc = null,
            Func<IQueryable<T>, string?, bool, IQueryable<T>>? sortFunc = null)
        {
            if (searchFunc != null)
                query = searchFunc(query, parameters.SearchTerm);

            if (sortFunc != null)
                query = sortFunc(query, parameters.OrderBy, parameters.IsDescending);

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
    }

}
