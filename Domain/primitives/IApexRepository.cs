using Domain.Shared.Pagination;

namespace Domain.primitives
{
    public interface IApexRepository<T>
    {
        public Task<PagedResult<T>> GetQueryableList(
            QueryParameters parameters,
            Func<IQueryable<T>, string?, IQueryable<T>>? searchFunc = null,
            Func<IQueryable<T>, string?, bool, IQueryable<T>>? sortFunc = null);

        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(Guid id);

        public Task<T> AddAsync(T t);

        public Task<T> UpdateAsync(T t);

        public Task<bool> DeleteAsync(Guid id);

        public Task<bool> IsExistsAsync(Guid id);
    }
}
