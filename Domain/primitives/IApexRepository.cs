using Domain.Shared.Pagination;

namespace Domain.primitives
{
    public interface IApexRepository<T>
    {
        public Task<PagedResult<T>> GetQueryableList(
            QueryParameters parameters,
            CancellationToken cancellationToken,
            Func<IQueryable<T>, string?, IQueryable<T>>? searchFunc = null,
            Func<IQueryable<T>, string?, bool, IQueryable<T>>? sortFunc = null);

        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<T> AddAsync(T t, CancellationToken cancellationToken);

        public Task<T> UpdateAsync(T t, CancellationToken cancellationToken);

        public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}
