

namespace Domain.primitives
{
    public interface IRepository<T>
    {
        IQueryable<T> GetQueryableList();

        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(Guid id);

        public Task<T> AddAsync(T t);

        public Task<T> UpdateAsync(T t);

        public Task<bool> DeleteAsync(Guid id);

        public Task<bool> IsExistsAsync(Guid id);
    }
}
